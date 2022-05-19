using System;
using System.Collections.Generic;
using PrintedMedia.Models.Repos;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepo _authorRepo;

        public AuthorService(IAuthorRepo authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public Author Create(CreateAuthorViewModel createAuthor)
        {
            Author author = new Author()
            {
                Name = createAuthor.Name,
                YearBorn = createAuthor.YearBorn,              
            };
            if(createAuthor.YearDied != null)
            {
                author.YearDied = createAuthor.YearDied;
            }     
            return _authorRepo.Create(author);
        }

        public bool Delete(int id)
        {
            Author author = _authorRepo.ReadById(id);
            if (author != null)
            {
                return _authorRepo.Delete(author);
            }
            return false;
        }

        public Author Edit(int id, CreateAuthorViewModel editAuthor)
        {
            Author author = _authorRepo.ReadById(id);
            if (author != null)
            {
                author.Name = editAuthor.Name;
                author.YearBorn = editAuthor.YearBorn;
                author.YearDied = editAuthor.YearDied;
                _authorRepo.Update(author);
            }
            return author;
        }

        public List<Author> GetAll()
        {
            return _authorRepo.Read();
        }

        public Author GetById(int id)
        {
            return _authorRepo.ReadById(id);
        }
    }
}
