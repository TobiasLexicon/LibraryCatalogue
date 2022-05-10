using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrintedMedia.Models.Data;

namespace PrintedMedia.Models.Repos
{
    public class PublisherRepo : IPublisherRepo
    {
        private readonly LibraryDbContext _libraryDbContext;

        public PublisherRepo(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public Publisher Add(Publisher publisher)
        {
            

            throw new NotImplementedException();
        }

        public bool Delete(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public List<Publisher> Read()
        {
            return _libraryDbContext.Publishers
                .Where(publ => publ.Name == "Wiley")
                .ToList();
        }

        public Publisher ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Publisher Update(Publisher publisher)
        {
            throw new NotImplementedException();
        }
    }
}
