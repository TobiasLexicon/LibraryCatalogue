using System;
using System.ComponentModel.DataAnnotations;

namespace PrintedMedia.Models.ViewModels
{
    public class CreateAuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1023)]
        public string Name { get; set; }

        [Required]
        [Range(1000, 2050)]
        public int YearBorn { get; set; }

        [Range(1000, 2050)]
        public int? YearDied { get; set; }


    }
}
