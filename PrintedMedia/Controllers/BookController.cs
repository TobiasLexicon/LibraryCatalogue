using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrintedMedia.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrintedMedia.Controllers
{
    public class BookController : Controller
    {
        IBookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
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
            createBook.PublisherList = _bookService.GetPublishers();

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

            createBook.PublisherList = _bookService.GetPublishers();

            return View(createBook);
        }
    }
}
