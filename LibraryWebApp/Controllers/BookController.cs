using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LibraryWebApp.Models;
using LibraryWebApp.Data;

namespace LibraryWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public BookController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var item = await _db.Book.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
