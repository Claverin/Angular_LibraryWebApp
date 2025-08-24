using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryWebApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Book> Books { get; set; }

    }
}