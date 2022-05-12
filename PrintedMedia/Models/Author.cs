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
        public int YearBorn { get; set; }
        public List<AuthorBook> BooksAuthored { get; set; }
    }
}
