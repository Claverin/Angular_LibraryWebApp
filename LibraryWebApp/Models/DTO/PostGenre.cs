using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace LibraryWebApp.Models.DTO
{
    public class PostGenre
    {
        public string Name { get; set; }

        public static Genre ToGenre(PostGenre pGenre)
        {
            var genre = new Genre();
            genre.Name = pGenre.Name;
            return genre;
        }
    }
    
}
