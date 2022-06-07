﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApp.Models
{
    public class BookTypeOfBook
    {
        [Key]
        public int Id { get; set; }
        public int IdBook { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book Book { get; set; }
        public int IdBookType { get; set; }
        [ForeignKey("IdBookType")]
        public virtual TypeOfBook TypeOfBook { get; set; }
    }
}