using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Book Authors")]
        public virtual ICollection<Author> Authors { get; set; }

        [DisplayName("Book Type")]
        public ICollection<Genre> Genres { get; set; }
    }
}