using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    public class TypeOfBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}