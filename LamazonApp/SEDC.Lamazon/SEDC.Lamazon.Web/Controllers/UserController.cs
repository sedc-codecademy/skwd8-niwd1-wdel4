using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.WebModels.ViewModels;

namespace SEDC.Lamazon.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LogIn()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult LogIn(LoginViewModel model)
        {
            return View();
        }

        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return View(model);
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}
