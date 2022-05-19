using System;
using System.Collections.Generic;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author GetById(int id);
        Author Create(CreateAuthorViewModel createAuthor);
        Author Edit(int id, CreateAuthorViewModel editAuthor);
        bool Delete(int id);
    }
}
