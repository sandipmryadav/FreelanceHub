using FreelanceHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceHub.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.UserName == "admin" && model.Password == "1234")
            {
                HttpContext.Session.SetString("UserName", model.UserName);
                return RedirectToAction("Index", "Client");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }
    }
}
