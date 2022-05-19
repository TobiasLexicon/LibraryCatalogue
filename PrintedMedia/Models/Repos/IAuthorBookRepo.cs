using System;
using System.Collections.Generic;

namespace PrintedMedia.Models.Repos
{
    public interface IAuthorBookRepo
    {
        AuthorBook Create(AuthorBook authorBook);
        List<AuthorBook> Read();
        List<AuthorBook> ReadByAuthorId(int id);
        List<AuthorBook> ReadByBookId(int id);
        bool Update(AuthorBook authorBook);
        bool Delete(AuthorBook authorBook);
    }
}
