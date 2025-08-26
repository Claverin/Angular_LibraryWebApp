using LibraryWebApp.Data;
using LibraryWebApp.Models;
using LibraryWebApp.Models.DTO;
using LibraryWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _db;
        private readonly IAuthorService _authors;
        private readonly IGenreService _genres;

        public BookService(ApplicationDbContext db, IAuthorService authors, IGenreService genres)
        {
            _db = db;
            _authors = authors;
            _genres = genres;
        }

        public async Task<List<BookDto>> GetAllAsync(CancellationToken ct)
        {
            var items = await _db.Book
                .AsNoTracking()
                .AsSplitQuery()
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .ToListAsync(ct);

            return items.Select(MapToDto).ToList();
        }

        public async Task<BookDto?> GetAsync(int id, CancellationToken ct)
        {
            var b = await _db.Book
                .AsNoTracking()
                .AsSplitQuery()
                .Include(x => x.Authors)
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(x => x.Id == id, ct);

            return b is null ? null : MapToDto(b);
        }

        public async Task<BookDto> CreateAsync(BookDto dto, CancellationToken ct)
        {
            var authors = await _authors.GetOrCreateManyAsync(dto.Authors, ct);
            var genres = await _genres.GetOrCreateManyAsync(dto.Genres, ct);

            var book = new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                Image = dto.Image,
                ReleaseDate = dto.ReleaseDate,
                Authors = authors,
                Genres = genres
            };

            _db.Book.Add(book);
            await _db.SaveChangesAsync(ct);
            return MapToDto(book);
        }

        public async Task<BookDto?> UpdateAsync(int id, BookDto dto, CancellationToken ct)
        {
            var book = await _db.Book
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefaultAsync(b => b.Id == id, ct);

            if (book is null) return null;

            book.Title = dto.Title;
            book.Description = dto.Description;
            book.Image = dto.Image;
            book.ReleaseDate = dto.ReleaseDate;

            book.Authors = await _authors.GetOrCreateManyAsync(dto.Authors, ct);
            book.Genres = await _genres.GetOrCreateManyAsync(dto.Genres, ct);

            await _db.SaveChangesAsync(ct);
            return MapToDto(book);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var b = await _db.Book.FindAsync(new object[] { id }, ct);
            if (b is null) return false;
            _db.Book.Remove(b);
            await _db.SaveChangesAsync(ct);
            return true;
        }

        private static BookDto MapToDto(Book b)
        {
            return new BookDto
            {
                Title = b.Title,
                Description = b.Description,
                Image = b.Image,
                ReleaseDate = b.ReleaseDate,
                Authors = b.Authors.Select(a => new AuthorDto { Name = a.Name, Surname = a.Surname }).ToList(),
                Genres = b.Genres.Select(g => new GenreDto { Name = g.Name }).ToList()
            };
        }
    }
}