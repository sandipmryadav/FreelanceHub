using FreelanceHub.Data;
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
    }
}
