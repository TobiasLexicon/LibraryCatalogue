using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintedMedia.Models
{
    public class CreateBookViewModel
    {
        [Required]
        [StringLength(1023)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Author { get; set; }

        [Required]
        [Range(1000, 2050)]
        public int Year { get; set; }
        [Required]
        [StringLength(255)]
        public string Publisher { get; set; }

        public List<string> PublisherList { get; set; }
    }
}
