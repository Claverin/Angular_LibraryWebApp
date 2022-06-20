namespace LibraryWebApp.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
    }
}