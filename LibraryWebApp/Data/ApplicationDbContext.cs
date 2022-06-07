using LibraryWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<TypeOfBook> TypeOfBook { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookTypeOfBook> BookTypeOfBook { get; set; }
    }
}