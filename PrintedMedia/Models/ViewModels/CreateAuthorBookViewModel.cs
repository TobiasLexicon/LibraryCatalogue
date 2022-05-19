using System;
using System.ComponentModel.DataAnnotations;

namespace PrintedMedia.Models.ViewModels
{
    public class CreateAuthorBookViewModel
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
