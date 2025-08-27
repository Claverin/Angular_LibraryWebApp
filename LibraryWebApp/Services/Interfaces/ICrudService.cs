namespace LibraryWebApp.Services.Interfaces
{
    public interface ICrudService<TDto>
    {
        Task<List<TDto>> GetAllAsync(CancellationToken ct);
        Task<TDto?> GetAsync(int id, CancellationToken ct);
        Task<TDto> CreateAsync(TDto dto, CancellationToken ct);
        Task<TDto?> UpdateAsync(int id, TDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}