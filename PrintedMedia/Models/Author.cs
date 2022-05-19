using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintedMedia.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="Born")]
        public int YearBorn { get; set; }

        [Display(Name = "Died")]
        public int? YearDied { get; set; }
        public List<AuthorBook> BooksAuthored { get; set; }
    }
}
