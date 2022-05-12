using System;
using System.Collections.Generic;

namespace PrintedMedia.Models.Repos
{
    public interface IPublisherRepo
    {
        List<Publisher> Read();
        Publisher ReadById(int id);
        Publisher Create(Publisher publisher);
        bool Update(Publisher publisher);
        bool Delete(Publisher publisher);
    }
}
