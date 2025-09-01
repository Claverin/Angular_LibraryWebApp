using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;

        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        [DisplayName("Book Authors")]
        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

        [DisplayName("Book Type")]
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}