using LibraryWebApp.Data;
using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;

namespace LibraryWebApp.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _db;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;

        public BookService(ApplicationDbContext db,
                           IGenreService genreService,
                           IAuthorService authorService)
        {
            _db = db;
            _genreService = genreService;
            _authorService = authorService;
        }
        //Maybe change to IActionResult
        public Book Save(PostBook pBook)
        {
            var genreList = pBook.Genres.Select(x => PostGenre.ToGenre(x));
            genreList = _genreService.saveIfNotExsists(genreList).ToList();
            var authorList = pBook.Authors.Select(x => PostAuthor.ToAuthor(x));
            authorList = _authorService.saveIfNotExsists(authorList).ToList();
            Book book = PostBook.ToBook(pBook);
            book.Authors = authorList;
            book.Genres = genreList;
            _db.Book.Add(book);
            _db.SaveChanges();
            return book;
        }

    
    }
}