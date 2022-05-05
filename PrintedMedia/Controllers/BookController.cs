using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrintedMedia.Models;
using PrintedMedia.Models.Services;
using PrintedMedia.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrintedMedia.Controllers
{
    public class BookController : Controller
    {
        readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;

        public BookController(IBookService bookService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _publisherService = publisherService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetBooks());
        }

        public IActionResult BookViewModelDemo()
        {
            return View(_bookService.GetBookViewModels());
        }

        
        public IActionResult Ajax()
        {
            return View();
        }

        public IActionResult GetBooks()
        {
            return PartialView("_BooksList", _bookService.GetBooks());
        }

        public IActionResult GetBooksJSON()
        {
            return Json(_bookService.GetBooks());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateBookViewModel createBook = new CreateBookViewModel();
            createBook.PublisherList = _publisherService.GetAll();
                

            return View(createBook);
        }


        [HttpPost]
        public IActionResult Create(CreateBookViewModel createBook)
        {
            if (ModelState.IsValid)
            {
                _bookService.CreateBook(createBook);
                return RedirectToAction("Index");
            }

            createBook.PublisherList = _publisherService.GetAll();

            return View(createBook);
        }

        [HttpPost]
        public IActionResult FindByYear(int year)
        {
            return PartialView("_BooksList", _bookService.GetBooksByYear(year));
        }
    }
}
