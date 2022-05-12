using System.Collections.Generic;

namespace PrintedMedia.Models.ViewModels

{
    public class BookViewModel
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public List<Author> Authors { get; set; }
            public int Year { get; set; }
            public string Publisher { get; set; }
            public string Reference { get; set; }
    }
}
