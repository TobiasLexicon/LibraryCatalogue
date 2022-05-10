using System;
using System.Collections.Generic;

namespace PrintedMedia.Models.Repos
{
    public interface IPublisherRepo
    {
        List<Publisher> Read();
        Publisher ReadById(int id);
        Publisher Add(Publisher publisher);
        Publisher Update(Publisher publisher);
        bool Delete(Publisher publisher);
    }
}
