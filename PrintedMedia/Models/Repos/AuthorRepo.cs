using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrintedMedia.Models.Data;

namespace PrintedMedia.Models.Repos
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly LibraryDbContext _context;

        public AuthorRepo(LibraryDbContext libraryDbContext)
        {
            _context = libraryDbContext;
        }

        public Author Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public bool Delete(Author author)
        {
            _context.Authors.Remove(author);
            return (_context.SaveChanges() > 0);
        }

        public List<Author> Read()
        {
            return _context.Authors
                .Include(b => b.BooksAuthored)
                .ThenInclude(a => a.Book)
                .ToList();
        }

        public Author ReadById(int id)
        {
            return _context.Authors
                .Include(b => b.BooksAuthored)
                .ThenInclude(a => a.Book)
                .SingleOrDefault(author => author.Id == id);
        }

        public bool Update(Author author)
        {
            _context.Authors.Update(author);
            return (_context.SaveChanges() > 0);
        }
    }
}
