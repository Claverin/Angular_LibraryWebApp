using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models.DTO
{
    public class PostBook
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<PostAuthor> Authors { get; set; }

        public IEnumerable<PostGenre> Genres { get; set; }

        public static Book ToBook(PostBook pBook)
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
