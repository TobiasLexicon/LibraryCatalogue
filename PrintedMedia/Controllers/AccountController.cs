using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrintedMedia.Models;
using PrintedMedia.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrintedMedia.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<LibraryUser> _userManager;

        public AccountController(UserManager<LibraryUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                LibraryUser libraryUser = new LibraryUser()
                {
                    UserName = createUserViewModel.UserName,
                    Email = createUserViewModel.Email
                };

                IdentityResult result = await _userManager.CreateAsync(libraryUser, createUserViewModel.Password);

                if (result.Succeeded)
                {
                    RedirectToAction("Login");
                }

                foreach(IdentityError identityError in result.Errors)
                {
                    ModelState.AddModelError(identityError.Code, identityError.Description);
                }
            }

            
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


    }
}
