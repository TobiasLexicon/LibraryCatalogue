using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintedMedia.Models
{
    public class BookService : IBookService
    {
        static int idCounter = 0;
        static List<Book> bookStorage = new List<Book>();
        static List<string> publishersStorage = new List<string>();

        public BookService()
        {
            if (publishersStorage.Count == 0)
            {
                publishersStorage.Add("Routledge");
                publishersStorage.Add("Sage");
                publishersStorage.Add("Wiley");
                publishersStorage.Add("O'Reilly");
                publishersStorage.Add("Manning");
                publishersStorage.Add("Harvard Business Press");
                publishersStorage.Add("Packt Publishing");

                bookStorage.Add(new Book() { Id = ++idCounter, Title = "C# – Up & Running", Author = "Spencer Moriot", Year = 2013, Publisher = "Routledge" });
                bookStorage.Add(new Book() { Id = ++idCounter, Title = "Design Now", Author = "Adam Bassett", Year = 1983, Publisher="Wiley" });
                bookStorage.Add(new Book() { Id = ++idCounter, Title = "Event-Driven Development", Author = "Jonathan Hudson", Year = 2019, Publisher = "Manning" });
                bookStorage.Add(new Book() { Id = ++idCounter, Title = "Myths of management", Author = "Cristian Scott", Year = 2021, Publisher = "Sage" });
                bookStorage.Add(new Book() { Id = ++idCounter, Title = "Easy Performance", Author = "Sara Hewison", Year = 2019, Publisher = "Harvard Business Press" });
                bookStorage.Add(new Book() { Id = ++idCounter, Title = "Continuous Breaks", Author = "Greg Murphy", Year = 2010, Publisher = "Manning" });
            }
        }

        public Book CreateBook(CreateBookViewModel createBook)
        {
            Book book = new Book() { Id = ++idCounter, Title = createBook.Title, Author = createBook.Author, Year = createBook.Year, Publisher = createBook.Publisher };
            bookStorage.Add(book);
            return book;
        }

        public List<Book> GetBooks()
        {
            return bookStorage;
        }

        public List<BookViewModel> GetBookViewModels()
        {
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            foreach(Book book in bookStorage)
            {
                BookViewModel bookViewModel = new BookViewModel();
                bookViewModel.Title = book.Title;
                bookViewModel.Author = book.Author;
                bookViewModel.Year = book.Year;
                bookViewModel.Publisher = book.Publisher;
                bookViewModel.Reference = GetReference(book);
                bookViewModels.Add(bookViewModel);
            }
            return bookViewModels;

        }

        public Book GetById(int id)
        {
            foreach (Book book in bookStorage)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public List<string> GetPublishers()
        {
            return publishersStorage;
        }

        public string GetReference(Book book)
        {
            string[] namingSeparate = book.Author.Split(' ');
            string reversed = $"{namingSeparate[1]}, {namingSeparate[0]}";
            string reference = $"{reversed}. ({book.Year}).{book.Title}. City: {book.Publisher}";
            return reference;
        }

        public List<Book> GetBooksByYear(int year)
        {
            List<Book> booksByYear = bookStorage.Where(book => book.Year == year).ToList();
            return booksByYear;
        }
    }
}
