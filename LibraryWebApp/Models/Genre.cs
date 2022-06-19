using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<BookGenre> Books { get; set; }

    }
}