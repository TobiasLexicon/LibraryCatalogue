using System;
using System.Collections.Generic;
using PrintedMedia.Models.Repos;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepo _publisherRepo;
        private readonly IBookRepo _bookRepo;

        public PublisherService(IPublisherRepo publisherRepo, IBookRepo bookRepo)
        {
            _publisherRepo = publisherRepo;
            _bookRepo = bookRepo;
        }

        public Publisher Create(CreatePublisherViewModel createPublisher)
        {
            Publisher publisher = new Publisher()
            {
                Name = createPublisher.Name,
            };
            if(createPublisher.BookId != null)
            {
                Book book = _bookRepo.ReadById((int)createPublisher.BookId);
                publisher.Books.Add(book);
            }
            return _publisherRepo.Create(publisher);
        }

        public bool Delete(int id)
        {
            Publisher publisher = _publisherRepo.ReadById(id);
            if(publisher != null)
            {
                return _publisherRepo.Delete(publisher);
            }
            return false;
        }

        public Publisher Edit(int id, CreatePublisherViewModel editPublisher)
        {
            Publisher publisher = _publisherRepo.ReadById(id);
            if(publisher != null)
            {
                publisher.Name = editPublisher.Name;
                _publisherRepo.Update(publisher);
            }
            return publisher;
        }

        public List<Publisher> GetAll()
        {
            return _publisherRepo.Read();
        }

        public Publisher GetById(int id)
        {
            return _publisherRepo.ReadById(id);
        }
    }
}
