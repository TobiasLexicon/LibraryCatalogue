using System;
using System.Collections.Generic;
using PrintedMedia.Models.ViewModels;

namespace PrintedMedia.Models.Services
{
    public interface IPublisherService
    {

        List<Publisher> GetAll();
        Publisher GetById(int id);
        Publisher Create(CreatePublisherViewModel createPublisherViewModel);
        Publisher Edit(int id, CreatePublisherViewModel createPublisherViewModel);
        bool Delete(int id);
    }
}
