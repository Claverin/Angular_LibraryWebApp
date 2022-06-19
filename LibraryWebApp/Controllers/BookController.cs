using LibraryWebApp.Data;
using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("id")]
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var item = _db.Book.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        public List<BookDto> GetAllBooks()
        {
            var items = _db.Book
                .Include("BookGenres")
                .Include("BookAuthors")
                .Select(x => new BookDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                    Authors = x.BookAuthors.ToList(),
                    Genres = x.BookGenres.ToList()
                }).ToList();

            return items;
        }

        [HttpPost]
        public IActionResult AddBook(PostBook book)
        {

            var genreList = book.Genres.Select(x => PostGenre.ToGenre(x)).ToList();
            var genreIds = saveGenresIfNotExsists(genreList);

            var authorList = book.Authors.Select(x => PostAuthor.ToAuthor(x)).ToList();
            var authorIds = saveGenresIfNotExsists(authorList);

            var bookList = book.Select(x => PostGenre.ToGenre(x)).ToList();
            var bookIds = saveGenresIfNotExsists(genreList);

            return Ok();
            //return CreatedAtAction(nameof(GetAllBooks), book.Id, book);
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] Book book)
        {
            var existingBook = _db.Book.Find(book.Id);

            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Description = book.Description;
            existingBook.Title = book.Title;
            existingBook.Image = book.Image;
            existingBook.ReleaseDate = book.ReleaseDate;
            existingBook.BookAuthors = book.BookAuthors;
            existingBook.BookGenres = book.BookGenres;
            _db.SaveChanges();
            return Ok(existingBook);
        }

        [Route("id")]
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _db.Book.Find(id);

            if (existingBook == null)
            {
                return NotFound();
            }
            _db.Book.Remove(existingBook);
            _db.SaveChanges();
            return Ok(existingBook);
        }
    }
}
