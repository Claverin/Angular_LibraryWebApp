namespace LibraryWebApp.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual IEnumerable<BookAuthor> Authors { get; set; }
        public virtual IEnumerable<BookGenre> Genres { get; set; }
    }
}