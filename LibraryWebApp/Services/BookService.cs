using LibraryWebApp.Data;
using LibraryWebApp.Models;

namespace LibraryWebApp.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _db;
        public Genre saveGenreIfNotExists(Genre genre)
        {
            var dbGenre = _db.Genre.FirstOrDefault(g => g.Name == genre.Name);
            if (dbGenre == null)
            {
                _db.Genre.Add(genre);
                _db.SaveChanges();
                dbGenre = genre;
            }

            return dbGenre;
        }

        public IEnumerable<Genre> saveGenresIfNotExsists(IEnumerable<Genre> genres)
        {
            return genres.Select(genres => saveGenreIfNotExists(genres));
        }
    }
}