using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Book Authors")]
        public virtual IEnumerable<Author> Authors { get; set; }
        [DisplayName("Book Type")]
        public virtual IEnumerable<Genre> Genres { get; set; }

    }
}