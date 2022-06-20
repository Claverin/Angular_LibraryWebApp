using LibraryWebApp.Data;
using LibraryWebApp.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryWebApp.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _db;
        public GenreService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Genre saveIfNotExist(Genre genre)
        {
            var dbGenre = _db.Genre.FirstOrDefault(g => g.Name == genre.Name);
            if (dbGenre == null)
            {
                dbGenre = Save(genre);
            }
            return dbGenre;
        }

        public IEnumerable<Genre> saveIfNotExsists(IEnumerable<Genre> genres)
        {
            return genres.Select(genre => saveIfNotExist(genre));
        }

        private Genre Save(Genre genre)
        {
            _db.Genre.Add(genre);
            _db.SaveChanges();
            return genre;
        }

    }
}
