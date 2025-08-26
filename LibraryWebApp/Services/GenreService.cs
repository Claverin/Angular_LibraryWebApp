using LibraryWebApp.Data;
using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;
using LibraryWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _db;
        public GenreService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<GenreDto>> GetAllAsync(CancellationToken ct)
        {
            var items = await _db.Genre.AsNoTracking().ToListAsync(ct);
            return items.Select(g => new GenreDto { Name = g.Name }).ToList();
        }

        public async Task<GenreDto?> GetAsync(int id, CancellationToken ct)
        {
            var g = await _db.Genre.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
            return g is null ? null : new GenreDto { Name = g.Name };
        }

        public async Task<GenreDto> CreateAsync(GenreDto dto, CancellationToken ct)
        {
            var g = new Genre { Name = dto.Name };
            _db.Genre.Add(g);
            await _db.SaveChangesAsync(ct);
            return new GenreDto { Name = g.Name };
        }

        public async Task<GenreDto?> UpdateAsync(int id, GenreDto dto, CancellationToken ct)
        {
            var g = await _db.Genre.FirstOrDefaultAsync(x => x.Id == id, ct);
            if (g is null) return null;
            g.Name = dto.Name;
            await _db.SaveChangesAsync(ct);
            return new GenreDto { Name = g.Name };
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var g = await _db.Genre.FindAsync(new object[] { id }, ct);
            if (g is null) return false;
            _db.Genre.Remove(g);
            await _db.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Genre>> GetOrCreateManyAsync(IEnumerable<GenreDto> dtos, CancellationToken ct)
        {
            var result = new List<Genre>();
            foreach (var dto in dtos)
            {
                var existing = await _db.Genre.FirstOrDefaultAsync(x => x.Name == dto.Name, ct);
                if (existing is null)
                {
                    existing = new Genre { Name = dto.Name };
                    _db.Genre.Add(existing);
                }
                result.Add(existing);
            }
            return result;
        }
    }
}