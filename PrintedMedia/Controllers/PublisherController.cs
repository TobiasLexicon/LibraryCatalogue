using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintedMedia.Models.Services;
using PrintedMedia.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrintedMedia.Controllers
{
    [Authorize(Roles="Admin")]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public IActionResult Index()
        {
            return View(_publisherService.GetAll());
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePublisherViewModel createPublisherViewModel)
        {
            if (ModelState.IsValid)
            {
                _publisherService.Create(createPublisherViewModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetPublisher(int id)
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_publisherService.Delete(id))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Unable to delete post";
            return View("Index", _publisherService.GetAll());
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            return Json(_publisherService.GetAll());
        }
    }
}
