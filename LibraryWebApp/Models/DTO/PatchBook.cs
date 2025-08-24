using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models.DTO
{
    public class PatchBook
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        public List<Author> Authors { get; set; } = new();
        public List<Genre> Genres { get; set; } = new();

        public static Book ToBook(PatchBook pBook)
        {
            var book = new Book();
            book.Title = pBook.Title;
            book.Description = pBook.Description;
            book.Image = pBook.Image;
            book.ReleaseDate = pBook.ReleaseDate;
            return book;
        }
    }
}
