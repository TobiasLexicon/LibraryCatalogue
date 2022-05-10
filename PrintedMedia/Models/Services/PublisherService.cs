using System;
using System.Collections.Generic;
using PrintedMedia.Models.Repos;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepo _publisherRepo;

        public PublisherService(IPublisherRepo publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }

        public Publisher Create(CreatePublisherViewModel createPublisherViewModel)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public Publisher Edit(int id, CreatePublisherViewModel createPublisherViewModel)
        {
            throw new NotImplementedException();
        }

        public List<Publisher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Publisher GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
