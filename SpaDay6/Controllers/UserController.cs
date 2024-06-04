using Microsoft.AspNetCore.Mvc;
using SpaDay6.Models;

namespace SpaDay6;

[Route("/user")]
public class UserController : Controller
{
    [HttpGet("add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("/user")]
    public IActionResult Submit (User aUser, string verify)
    {
        if (aUser.Password != verify)
        {
            ViewBag.Error = "Passwords must match.";
            ViewBag.User = aUser;
            return View("Add");
        }
        ViewBag.Username = aUser.Username;
        return View("Index");
    }
}
