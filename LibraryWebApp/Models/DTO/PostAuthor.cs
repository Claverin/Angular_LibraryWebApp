using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models.DTO
{
    public class PostAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public static Author ToAuthor(PostAuthor pAuthor)
        {
            var author = new Author();
            author.Name = pAuthor.Name;
            author.Surname = pAuthor.Surname;
            return author;
        }
    }
}
