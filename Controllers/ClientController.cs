using FreelanceHub.Data;
using FreelanceHub.Models;
using FreelanceHub.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceHub.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

          
        public IActionResult Index(string search , int page = 1)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int pageSize = 5;

            var clients = _clientRepository.Search(search);

            int totalClients = _clientRepository.GetTotalClients();
            ViewBag.TotalClients = totalClients;

            int clientsWithPhone = _clientRepository.GetClientsWithPhone();

            int clientsWithoutPhone = _clientRepository.GetClientsWithoutPhone();

            int totalUsers = _clientRepository.GetTotalUsers();

            ViewBag.ClientsWithPhone = clientsWithPhone;
            ViewBag.ClientsWithoutPhone = clientsWithoutPhone;
            ViewBag.TotalUsers = totalUsers;



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

                _clientRepository.Add(client);
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

            var client =  _clientRepository.GetById(id);
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
                _clientRepository.Update(client);
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
            var client = _clientRepository.GetById(id);
           

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
            _clientRepository.Delete(id);
            TempData["Success"] = "Client is deleted successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var client = _clientRepository.GetById(id);
            if (client == null) return NotFound();
            return View(client);
        }
    }
}