using System;
using System.Collections.Generic;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public interface IAuthorBookService
    {
        List<AuthorBook> GetAll();
        AuthorBook GetById(CreateAuthorBookViewModel createAuthorBook);
        AuthorBook Create(CreateAuthorBookViewModel createAuthorBook);
        bool Delete(CreateAuthorBookViewModel deleteAuthorBook);
    }
}
