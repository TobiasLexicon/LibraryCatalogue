using System;
using System.Collections.Generic;

namespace PrintedMedia.Models.Repos
{
    public interface IBookRepo
    {

        Book Create(Book book);

        List<Book> Read();

        Book ReadById(int id);

        Book Update(Book book);

        bool Delete(Book book);

    }
}
