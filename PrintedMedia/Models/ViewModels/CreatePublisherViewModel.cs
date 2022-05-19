using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintedMedia.Models.ViewModels
{
    public class CreatePublisherViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? BookId { get; set; }
    }
}
