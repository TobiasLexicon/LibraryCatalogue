using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrintedMedia.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public List<AuthorBook> Authors { get; set; }
        public int Year { get; set; }

        [ForeignKey("Publisher")]
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
