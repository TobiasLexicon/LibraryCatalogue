using System;
using System.Collections.Generic;
using System.Linq;
using PrintedMedia.Models.Repos;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public class BookService : IBookService
    {
        private readonly IPublisherService _publisherService;
        private readonly IBookRepo _bookRepo;

        //static int idCounter = 0;
        //static List<Book> bookStorage = new List<Book>();
        //static List<string> publishersStorage = new List<string>();

        public BookService(IPublisherService publisherService, IBookRepo bookRepo)
        {
            _publisherService = publisherService;
            _bookRepo = bookRepo;

            //if (publishersStorage.Count == 0)
            //{
            //    publishersStorage.Add("Routledge");
            //    publishersStorage.Add("Sage");
            //    publishersStorage.Add("Wiley");
            //    publishersStorage.Add("O'Reilly");
            //    publishersStorage.Add("Manning");
            //    publishersStorage.Add("Harvard Business Press");
            //    publishersStorage.Add("Packt Publishing");

                //bookStorage.Add(new Book() { Id = ++idCounter, Title = "C# – Up & Running", Author = "Spencer Moriot", Year = 2013, Publisher = "Routledge" });
                //bookStorage.Add(new Book() { Id = ++idCounter, Title = "Design Now", Author = "Adam Bassett", Year = 1983, Publisher="Wiley" });
                //bookStorage.Add(new Book() { Id = ++idCounter, Title = "Event-Driven Development", Author = "Jonathan Hudson", Year = 2019, Publisher = "Manning" });
                //bookStorage.Add(new Book() { Id = ++idCounter, Title = "Myths of management", Author = "Cristian Scott", Year = 2021, Publisher = "Sage" });
                //bookStorage.Add(new Book() { Id = ++idCounter, Title = "Easy Performance", Author = "Sara Hewison", Year = 2019, Publisher = "Harvard Business Press" });
                //bookStorage.Add(new Book() { Id = ++idCounter, Title = "Continuous Breaks", Author = "Greg Murphy", Year = 2010, Publisher = "Manning" });
           // }
        }

        public Book CreateBook(CreateBookViewModel createBook)
        {
            Book book = new Book() {
                Title = createBook.Title,
                Author = createBook.Author,
                Year = createBook.Year,
                Publisher = _publisherService.GetById(createBook.PublisherId) };            
            return _bookRepo.Create(book);
        }

        public List<Book> GetBooks()
        {
            return _bookRepo.Read();
        }

        public List<BookViewModel> GetBookViewModels()
        {
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            foreach(Book book in _bookRepo.Read())
            {
                BookViewModel bookViewModel = new BookViewModel();
                bookViewModel.Title = book.Title;
                bookViewModel.Author = book.Author;
                bookViewModel.Year = book.Year;
               
                bookViewModel.Reference = GetReference(book);
                bookViewModels.Add(bookViewModel);
            }
            return bookViewModels;
        }

        public Book GetById(int id)
        {
            return _bookRepo.ReadById(id);
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
            List<Book> booksByYear = _bookRepo.Read().Where(book => book.Year == year).ToList();
            return booksByYear;
        }
    }
}
