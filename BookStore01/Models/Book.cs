using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore01.Models
{
     
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        //[ForeignKey("Genre")]
        public int GenreId { get; set; }
       // public Genre Genre { get; set; }
        public int YearRelease { get; set; }
    }
}