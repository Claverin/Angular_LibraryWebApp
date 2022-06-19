using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryWebApp.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [JsonIgnore]
        public IEnumerable<BookAuthor> Books { get; set; }
    }
}