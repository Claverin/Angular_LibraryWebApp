using LibraryWebApp.Data;
using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IBookService _bookService;

        public BookController(ApplicationDbContext db, IBookService bookService)
        {
            _db = db;
            _bookService = bookService;
        }

        [Route("id")]
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var item = _db.Book
                .Include("Authors")
                .Include("Genres")
                .FirstOrDefault(s => s.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        public List<BookDto> GetAllBooks()
        {
            return _db.Book
                .Include("Authors")
                .Include("Genres").Select(it => new BookDto
                {
                    Id = it.Id,
                    Title = it.Title,
                    ReleaseDate = it.ReleaseDate,
                    Authors = it.Authors.ToList(),
                    Genres = it.Genres.ToList()
                }).ToList();

        }

        [HttpPost]
        public IActionResult AddBook(PostBook book)
        {
            _bookService.Save(book);
            return Ok();
        }

        [Route("id")]
        [HttpPatch("{id}")]
        public IActionResult UpdateBook(PatchBook book)
        {
            Console.WriteLine(book.ToString());
            var existingBook = _db.Book.Find(book.Id);

            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Description = book.Description;
            existingBook.Title = book.Title;
            existingBook.Image = book.Image;
            existingBook.ReleaseDate = book.ReleaseDate;
            existingBook.Authors = book.Authors;
            existingBook.Genres = book.Genres;
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
