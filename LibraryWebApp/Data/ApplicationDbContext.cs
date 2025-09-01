using LibraryWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Book> Book { get; set; } = null!;
        public DbSet<Author> Author { get; set; } = null!;
        public DbSet<Genre> Genre { get; set; }= null!;
    }
}