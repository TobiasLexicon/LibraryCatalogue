using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrintedMedia.Models.Services;
using PrintedMedia.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrintedMedia.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePublisherViewModel createPublisherViewModel)
        {
            _publisherService.Create(createPublisherViewModel);
            return View();
        }

        public IActionResult GetPublisher(int id)
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            return Json(_publisherService.GetAll());
        }
    }
}
