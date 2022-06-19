﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Book Authors")]
        public IEnumerable<BookAuthor> BookAuthors { get; set; }
        [DisplayName("Book Type")]
        public IEnumerable<BookGenre> BookGenres { get; set; }

    }
}