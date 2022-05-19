using System;
using System.Collections.Generic;

namespace PrintedMedia.Models.Repos
{
    public interface IAuthorRepo
    {
        Author Create(Author author);
        List<Author> Read();
        Author ReadById(int id);
        bool Update(Author author);
        bool Delete(Author author);
    }
}
