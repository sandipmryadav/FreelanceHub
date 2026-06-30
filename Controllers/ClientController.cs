using FreelanceHub.Data;
using FreelanceHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceHub.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController (AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create (Client client)
        {
            if(ModelState.IsValid)
            {

            }
            return View(client);
        }
    }
}
