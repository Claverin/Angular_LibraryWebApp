using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryWebApp.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}