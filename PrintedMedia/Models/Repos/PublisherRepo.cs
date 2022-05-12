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

        public Publisher Create(Publisher publisher)
        {
            _libraryDbContext.Publishers.Add(publisher);
            _libraryDbContext.SaveChanges();
            return publisher;
        }

        public bool Delete(Publisher publisher)
        {
            _libraryDbContext.Publishers.Remove(publisher);
            return (_libraryDbContext.SaveChanges() > 0);
        }

        public List<Publisher> Read()
        {
            return _libraryDbContext.Publishers               
                .ToList();
        }

        public Publisher ReadById(int id)
        {
            return _libraryDbContext.Publishers
                .SingleOrDefault(publisher => publisher.Id == id);
        }

        public bool Update(Publisher publisher)
        {
            _libraryDbContext.Publishers.Update(publisher);
            return (_libraryDbContext.SaveChanges() > 0);
        }
    }
}
