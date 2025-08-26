using LibraryWebApp.Models.DTO;

namespace LibraryWebApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync(CancellationToken ct);
        Task<BookDto?> GetAsync(int id, CancellationToken ct);
        Task<BookDto> CreateAsync(BookDto dto, CancellationToken ct);
        Task<BookDto?> UpdateAsync(int id, BookDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}