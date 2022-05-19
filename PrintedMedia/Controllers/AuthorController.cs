using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintedMedia.Models;
using PrintedMedia.Models.Services;
using PrintedMedia.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrintedMedia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            return View(_authorService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorViewModel createAuthor)
        {
            if (ModelState.IsValid)
            {
                _authorService.Create(createAuthor);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Author author = _authorService.GetById(id);
            CreateAuthorViewModel viewModel = new CreateAuthorViewModel();
            viewModel.Name = author.Name;
            viewModel.YearBorn = author.YearBorn;
            viewModel.YearDied = author.YearDied;
            viewModel.Id = author.Id;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateAuthorViewModel editAuthor)
        {
            if (ModelState.IsValid)
            {
                _authorService.Edit(id, editAuthor);
                return RedirectToAction("Index");
            }
            return View(editAuthor);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_authorService.Delete(id))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Unable to delete post";
            return View("Index", _authorService.GetAll());
        }
    }
}
