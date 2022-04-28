using System;
using System.Collections.Generic;

namespace PrintedMedia.Models
{
    public interface IBookService
    {
        List<Book> GetBooks();
        List<BookViewModel> GetBookViewModels();
        List<string> GetPublishers();
        Book CreateBook(CreateBookViewModel createBook);
        Book GetById(int id);
        string GetReference(Book book);
        List<Book> GetBooksByYear(int year);
    }
}
