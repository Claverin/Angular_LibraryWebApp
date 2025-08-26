using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;

namespace LibraryWebApp.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAsync(CancellationToken ct);
        Task<AuthorDto?> GetAsync(int id, CancellationToken ct);
        Task<AuthorDto> CreateAsync(AuthorDto dto, CancellationToken ct);
        Task<AuthorDto?> UpdateAsync(int id, AuthorDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<List<Author>> GetOrCreateManyAsync(IEnumerable<AuthorDto> dtos, CancellationToken ct);
    }
}