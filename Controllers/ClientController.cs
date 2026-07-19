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

        public IActionResult Index(string search)
        {
            var clients = _context.Clients.AsQueryable();

            if(!string.IsNullOrWhiteSpace(search))
            {
                clients = clients.Where(c =>
                c.Name.Contains(search) ||
                c.Email.Contains(search) ||
                c.CompanyName.Contains(search));
            }
            return View(clients.ToList());
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
                TempData["Success"] = "Client created successfully.";
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
        public IActionResult Edit(Client client)
        {
            Console.WriteLine("POST Edit called");
            if (ModelState.IsValid)
            {
                _context.Clients.Update(client);
                _context.SaveChanges();
                TempData["Success"] = "Client is Updated Successfully";
                return RedirectToAction("Index");
            }

            return View(client);
        }

        public IActionResult Delete(int id)
            {
               var client =  _context.Clients.Find(id);
           

                if(client == null)
                {
                    return NotFound();
                }
            return View(client);

            }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = _context.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }
            _context.Clients.Remove(client);
            _context.SaveChanges();
            TempData["Success"] = "Client is deleted successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();
            return View(client);
        }
    }
}
