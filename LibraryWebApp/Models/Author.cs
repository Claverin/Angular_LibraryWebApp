﻿using System.ComponentModel.DataAnnotations;

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
        public virtual List<BookAuthor> BookAuthor { get; set; }
    }
}