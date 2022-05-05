using System;
using System.Collections.Generic;
using System.Linq;
using PrintedMedia.Models.Data;

namespace PrintedMedia.Models.Repos
{
    public class BookRepo : IBookRepo
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookRepo(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public Book Create(Book book)
        {
            _libraryDbContext.Add(book);
            _libraryDbContext.SaveChanges();
            return book;
        }

        public bool Delete(Book book)
        {
            _libraryDbContext.Remove(book);
            int change = _libraryDbContext.SaveChanges();
            if(change == 2) { return true; }
            return false;
        }

        public List<Book> Read()
        {
            return _libraryDbContext.Books.ToList();
        }

        public Book ReadById(int id)
        {
            return _libraryDbContext.Books                
                .SingleOrDefault(book => book.Id == id);
        }

        public Book Update(Book book)
        {
            _libraryDbContext.Books.Update(book);
            _libraryDbContext.SaveChanges();
            return book;
            
        }
    }
}
