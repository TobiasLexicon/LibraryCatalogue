using System;
using System.Collections.Generic;
using System.Linq;
using PrintedMedia.Models.Data;

namespace PrintedMedia.Models.Repos
{
    public class AuthorBookRepo : IAuthorBookRepo
    {
        private readonly LibraryDbContext _context;

        public AuthorBookRepo(LibraryDbContext libraryDbContext)
        {
            _context = libraryDbContext;
        }

        public AuthorBook Create(AuthorBook authorBook)
        {
            _context.AuthorBooks.Add(authorBook);
            _context.SaveChanges();
            return authorBook;
        }

        public bool Delete(AuthorBook authorBook)
        {
            _context.AuthorBooks.Remove(authorBook);
            return (_context.SaveChanges() > 0);
        }

        public List<AuthorBook> Read()
        {
            return _context.AuthorBooks.ToList();
        }

        public List<AuthorBook> ReadByAuthorId(int id)
        {
            return _context.AuthorBooks
                .Where(ab => ab.AuthorId == id)
                .ToList();               
        }

        public List<AuthorBook> ReadByBookId(int id)
        {
            return _context.AuthorBooks
                .Where(ab => ab.BookId == id)
                .ToList();
        }

        public bool Update(AuthorBook authorBook)
        {
            _context.AuthorBooks.Update(authorBook);
            return (_context.SaveChanges() > 0);
        }
    }
}
