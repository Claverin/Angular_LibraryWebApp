using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryWebApp.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}