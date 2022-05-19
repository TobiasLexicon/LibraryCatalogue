using System;
using System.Collections.Generic;
using System.Linq;
using PrintedMedia.Models.Repos;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAuthorBookRepo _authorBookRepo;

        public AuthorBookService(IAuthorBookRepo authorBookRepo)
        {
            _authorBookRepo = authorBookRepo;
        }

        public AuthorBook Create(CreateAuthorBookViewModel createAuthorBook)
        {
            AuthorBook authorBook = new AuthorBook()
            {
                AuthorId = createAuthorBook.AuthorId,
                BookId = createAuthorBook.BookId,
            };
            return _authorBookRepo.Create(authorBook);
        }

        public bool Delete(CreateAuthorBookViewModel deleteAuthorBook)
        {
            AuthorBook authorBook = _authorBookRepo
                .ReadByAuthorId(deleteAuthorBook.AuthorId)
                .SingleOrDefault(b => b.BookId == deleteAuthorBook.BookId);
            if (authorBook != null)
            {
                return _authorBookRepo.Delete(authorBook);
            }
            return false;
        }

        public List<AuthorBook> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuthorBook GetById(CreateAuthorBookViewModel createAuthorBook)
        {
            throw new NotImplementedException();
        }

        public List<AuthorBook> GetAuthorsOfBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
