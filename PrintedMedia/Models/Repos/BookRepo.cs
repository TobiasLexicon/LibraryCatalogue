using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            _libraryDbContext.Books.Add(book);
            _libraryDbContext.SaveChanges();
            return book;
        }

        public bool Delete(Book book)
        {
            _libraryDbContext.Books.Remove(book);
            return (_libraryDbContext.SaveChanges() > 0);
        }

        public List<Book> Read()
        {
            return _libraryDbContext.Books
                .Include(b => b.Authors)
                .ThenInclude(a => a.Author)
                .ToList();
        }

        public Book ReadById(int id)
        {
            return _libraryDbContext.Books
                .Include(b => b.Authors)
                .ThenInclude(a => a.Author)
                .SingleOrDefault(book => book.Id == id);
        }

        public bool Update(Book book)
        {
            _libraryDbContext.Books.Update(book);
            return (_libraryDbContext.SaveChanges() > 0);            
        }
    }
}
