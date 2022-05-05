using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintedMedia.Models.ViewModels
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
        public int PublisherId { get; set; }

        public List<Publisher> PublisherList { get; set; }
    }
}
