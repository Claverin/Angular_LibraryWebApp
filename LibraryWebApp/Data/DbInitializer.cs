using LibraryWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Data
{
    public static class DbSeeder
    {
        public static void Seed(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            db.Database.Migrate();

            if (!db.Book.Any())
            {
                var author = new Author
                {
                    Name = "John",
                    Surname = "Doe"
                };

                var genre = new Genre
                {
                    Name = "Science Fiction"
                };

                var book = new Book
                {
                    Title = "Sci-Fi Adventure",
                    Description = "A science fiction novel.",
                    Image = "SFAdventure.jpg",
                    ReleaseDate = new DateTime(2020, 1, 1),
                    Authors = new List<Author> { author },
                    Genres = new List<Genre> { genre }
                };

                db.Book.Add(book);
                db.SaveChanges();
            }
        }
    }
}