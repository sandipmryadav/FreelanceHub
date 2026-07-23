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

        public IActionResult Index(string search , int page = 1)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int pageSize = 5;
            
            var clients = _context.Clients.OrderByDescending(c => c.CreatedAt).AsQueryable();

            if(!string.IsNullOrWhiteSpace(search))
            {
                clients = clients.Where(c =>
                c.Name.Contains(search) ||
                c.Email.Contains(search) ||
                c.CompanyName.Contains(search));
            }
            int totalClients = _context.Clients.Count();
            ViewBag.TotalClients = totalClients;
            int totalPages = (int)Math.Ceiling((double)totalClients / pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            clients = clients.Skip((page - 1) * pageSize).Take(pageSize);
            return View(clients.ToList());
        }


        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }

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
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();
            return View(client);
        }
    }
}