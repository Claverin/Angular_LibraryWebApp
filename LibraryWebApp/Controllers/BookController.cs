using LibraryWebApp.Data;
using LibraryWebApp.Models;
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
                .Include("Genre")
                .Include("BookAuthor")
                .Select(x => new BookDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                    Authors = x.BookAuthor,
                    Genres = x.Genre
                }).ToList();

            return items;
        }
    }
}
