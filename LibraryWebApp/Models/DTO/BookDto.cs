namespace LibraryWebApp.Models.DTO
{
    public class BookDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<AuthorDto> Authors { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}