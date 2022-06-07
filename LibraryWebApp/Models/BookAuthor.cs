using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApp.Models
{
    public class BookAuthor
    {
        [Key]
        public int Id { get; set; }
        public int IdBook { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book Book { get; set; }
        public int IdAuthor { get; set; }
        [ForeignKey("IdAuthor")]
        public virtual Author Author { get; set; }
    }
}