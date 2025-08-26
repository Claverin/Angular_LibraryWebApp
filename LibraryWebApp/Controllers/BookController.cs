using LibraryWebApp.Data;
using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryWebApp.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IBookService _bookService;

        public BookController(ApplicationDbContext db, IBookService bookService)
        {
            _db = db;
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var item = _db.Book
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefault(s => s.Id == id);

            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet]
        public List<BookDto> GetAllBooks()
        {
            return _db.Book
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Select(it => new BookDto
                {
                    Id = it.Id,
                    Title = it.Title,
                    ReleaseDate = it.ReleaseDate,
                    Authors = it.Authors.ToList(),
                    Genres = it.Genres.ToList()
                })
                .ToList();
        }

        [HttpPost]
        public IActionResult AddBook(PostBook book)
        {
            _bookService.Save(book);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] PatchBook book)
        {
            var existingBook = _db.Book
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefault(b => b.Id == id);

            if (existingBook == null) return NotFound();

            existingBook.Description = book.Description;
            existingBook.Title = book.Title;
            existingBook.Image = book.Image;
            existingBook.ReleaseDate = book.ReleaseDate;

            var authorIds = book.Authors?.Select(a => a.Id).ToList() ?? new List<int>();
            var genreIds = book.Genres?.Select(g => g.Id).ToList() ?? new List<int>();

            existingBook.Authors = _db.Author
                .Where(a => authorIds.Contains(a.Id))
                .ToList();

            existingBook.Genres = _db.Genre
                .Where(g => genreIds.Contains(g.Id))
                .ToList();

            _db.SaveChanges();
            return Ok(existingBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _db.Book.Find(id);
            if (existingBook == null) return NotFound();

            _db.Book.Remove(existingBook);
            _db.SaveChanges();
            return Ok(existingBook);
        }
    }
}