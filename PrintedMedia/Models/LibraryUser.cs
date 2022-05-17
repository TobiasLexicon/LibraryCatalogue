using System;
using Microsoft.AspNetCore.Identity;

namespace PrintedMedia.Models
{
    public class LibraryUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
