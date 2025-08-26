using LibraryWebApp.Data;
using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;
using LibraryWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _db;
        public AuthorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<AuthorDto>> GetAllAsync(CancellationToken ct)
        {
            var items = await _db.Author.AsNoTracking().ToListAsync(ct);
            return items.Select(a => new AuthorDto { Name = a.Name, Surname = a.Surname }).ToList();
        }

        public async Task<AuthorDto?> GetAsync(int id, CancellationToken ct)
        {
            var a = await _db.Author.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
            return a is null ? null : new AuthorDto { Name = a.Name, Surname = a.Surname };
        }

        public async Task<AuthorDto> CreateAsync(AuthorDto dto, CancellationToken ct)
        {
            var a = new Author { Name = dto.Name, Surname = dto.Surname };
            _db.Author.Add(a);
            await _db.SaveChangesAsync(ct);
            return new AuthorDto { Name = a.Name, Surname = a.Surname };
        }

        public async Task<AuthorDto?> UpdateAsync(int id, AuthorDto dto, CancellationToken ct)
        {
            var a = await _db.Author.FirstOrDefaultAsync(x => x.Id == id, ct);
            if (a is null) return null;
            a.Name = dto.Name;
            a.Surname = dto.Surname;
            await _db.SaveChangesAsync(ct);
            return new AuthorDto { Name = a.Name, Surname = a.Surname };
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var a = await _db.Author.FindAsync(new object[] { id }, ct);
            if (a is null) return false;
            _db.Author.Remove(a);
            await _db.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Author>> GetOrCreateManyAsync(IEnumerable<AuthorDto> dtos, CancellationToken ct)
        {
            var result = new List<Author>();
            foreach (var dto in dtos)
            {
                var existing = await _db.Author
                    .FirstOrDefaultAsync(x => x.Name == dto.Name && x.Surname == dto.Surname, ct);
                if (existing is null)
                {
                    existing = new Author { Name = dto.Name, Surname = dto.Surname };
                    _db.Author.Add(existing);
                }
                result.Add(existing);
            }
            return result;
        }
    }
}