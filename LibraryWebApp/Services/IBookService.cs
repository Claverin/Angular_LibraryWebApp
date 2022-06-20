using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;

namespace LibraryWebApp.Services
{
    public interface IBookService
    {
        Book Save(PostBook pb);
    }
}
