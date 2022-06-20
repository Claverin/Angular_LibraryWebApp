using LibraryWebApp.Data;
using LibraryWebApp.Models;

namespace LibraryWebApp.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _db;
        public AuthorService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Author saveIfNotExist(Author author)
        {
            var dbAuthor = _db.Author
                .FirstOrDefault(g => g.Name == author.Name && g.Surname == author.Surname);
            if (dbAuthor == null)
            {
                dbAuthor = Save(author);
            }

            return dbAuthor;
        }

        public IEnumerable<Author> saveIfNotExsists(IEnumerable<Author> authors)
        {
            return authors.Select(authors => saveIfNotExist(authors));
        }

        private Author Save(Author author)
        {
            _db.Author.Add(author);
            _db.SaveChanges();
            return author;
        }
    }

}