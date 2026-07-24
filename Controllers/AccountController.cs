using FreelanceHub.Data;
using FreelanceHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController (AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _context.Users
                .FirstOrDefault(u =>
                u.Email == model.Email && u.PasswordHash == model.Password
                );

            if(user != null)
            {
                HttpContext.Session.SetString("UserName", user.Name);
                return RedirectToAction("Index", "Client");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }
    }
}
