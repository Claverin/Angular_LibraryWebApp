using LibraryWebApp.Models;

namespace LibraryWebApp.Services
{
    public interface IGenreService
    {
        Genre saveIfNotExist(Genre genre);
        IEnumerable<Genre> saveIfNotExsists(IEnumerable<Genre> genres);
    }
}
