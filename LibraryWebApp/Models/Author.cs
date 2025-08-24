using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryWebApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore]
        public IEnumerable<Book> Books { get; set; }
    }
}