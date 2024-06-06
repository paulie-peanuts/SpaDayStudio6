using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay6;
using SpaDay6.Models;
using SpaDay6.ViewModels;
using System.ComponentModel.DataAnnotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay6.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/add")]
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new();
            return View(addUserViewModel);
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                if (addUserViewModel.Password == addUserViewModel.Verify)
                {
                    User newUser = new()
                    {
                        Username = addUserViewModel.Username,
                        Password = addUserViewModel.Password,
                        Email = addUserViewModel.Email,
                    };
                    return View("Index", newUser);
                }
                else 
                {
                    ViewBag.error = "Passwords don't match.";
                    return View("Add", addUserViewModel);
                }
            }
            else
            {
    
                return View("Add", addUserViewModel);
            }
        }
    }
}

