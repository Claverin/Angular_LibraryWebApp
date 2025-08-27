using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;

namespace LibraryWebApp.Services.Interfaces
{
    public interface IAuthorService : ICrudService<AuthorDto>
    {
        Task<List<Author>> GetOrCreateManyAsync(IEnumerable<AuthorDto> dtos, CancellationToken ct);
    }
}