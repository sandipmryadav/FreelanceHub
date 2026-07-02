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

        public IActionResult Index()
        {
            var clients = _context.Clients.ToList();
            return View(clients);
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

                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public IActionResult Edit (int id)
        {
            
          var client =  _context.Clients.Find(id);
            if(client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]

        public IActionResult Edit (Client client)
        {
            
            if(ModelState.IsValid)
            {
                _context.Clients.Update(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }
    }
}
