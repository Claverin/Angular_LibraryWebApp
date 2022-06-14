namespace LibraryWebApp.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual List<BookAuthor> Authors { get; set; }
        public virtual List<BookGenre> Genres { get; set; }
    }
}