using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;

namespace LibraryWebApp.Services.Interfaces
{
    public interface IGenreService : ICrudService<GenreDto>
    {
        Task<List<Genre>> GetOrCreateManyAsync(IEnumerable<GenreDto> dtos, CancellationToken ct);
    }
}
