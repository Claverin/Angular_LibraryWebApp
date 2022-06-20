using LibraryWebApp.Models;

namespace LibraryWebApp.Services
{
    public interface IAuthorService
    {
        Author saveIfNotExist(Author author);
        IEnumerable<Author> saveIfNotExsists(IEnumerable<Author> authors);
    }
}
