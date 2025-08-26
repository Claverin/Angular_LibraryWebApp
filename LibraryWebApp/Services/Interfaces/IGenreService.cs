using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;

namespace LibraryWebApp.Services.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllAsync(CancellationToken ct);
        Task<GenreDto?> GetAsync(int id, CancellationToken ct);
        Task<GenreDto> CreateAsync(GenreDto dto, CancellationToken ct);
        Task<GenreDto?> UpdateAsync(int id, GenreDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<List<Genre>> GetOrCreateManyAsync(IEnumerable<GenreDto> dtos, CancellationToken ct);
    }
}
