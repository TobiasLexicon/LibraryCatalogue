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
    [Authorize(Roles ="Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<LibraryUser> _userManager;
        private readonly SignInManager<LibraryUser> _signInManager;

        public AccountController(UserManager<LibraryUser> userManager,
            SignInManager<LibraryUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        [AllowAnonymous]
        [HttpPost]
        async public Task<IActionResult> Login(string userName, string password)
        {
            Microsoft.AspNetCore.Identity.SignInResult result =
                await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return View();
        }



    }
}
