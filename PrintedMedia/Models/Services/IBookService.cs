using System;
using System.Collections.Generic;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        List<BookViewModel> GetBookViewModels();
        Book CreateBook(CreateBookViewModel createBook);
        Book GetById(int id);
        //string GetReference(Book book);
        List<Book> GetBooksByYear(int year);
    }
}
