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
        private readonly IAuthorRepo _authorRepo;

        public BookService(IPublisherService publisherService,
            IBookRepo bookRepo)
        {
            _publisherService = publisherService;
            _bookRepo = bookRepo;

        }

        public Book CreateBook(CreateBookViewModel createBook)
        {
            Book book = new Book() {
                Title = createBook.Title,               
                Year = createBook.Year,
                Publisher = _publisherService.GetById(createBook.PublisherId) };
            Book createdBook = _bookRepo.Create(book);
            AuthorBook authorBook = new AuthorBook() { AuthorId = createBook.AuthorId, BookId = createdBook.Id };
            // _authorBookRepo.Create(authorBook);
            return _bookRepo.ReadById(createdBook.Id);
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
                foreach(AuthorBook authorBooks in book.Authors)
                {                
                    bookViewModel.Authors.Add(authorBooks.Author);
                }

                bookViewModel.Year = book.Year;
               
                //bookViewModel.Reference = GetReference(book);
                bookViewModels.Add(bookViewModel);
            }
            return bookViewModels;
        }

        public Book GetById(int id)
        {
            return _bookRepo.ReadById(id);
        }

        //public string GetReference(Book book)
        //{
        //    string[] namingSeparate = book.Author.Split(' ');
        //    string reversed = $"{namingSeparate[1]}, {namingSeparate[0]}";
        //    string reference = $"{reversed}. ({book.Year}).{book.Title}. City: {book.Publisher}";
        //    return reference;
        //}

        public List<Book> GetBooksByYear(int year)
        {
            List<Book> booksByYear = _bookRepo
                .Read()
                .Where(book => book.Year == year)
                .ToList();
            return booksByYear;
        }
    }
}
