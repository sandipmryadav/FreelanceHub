using Microsoft.AspNetCore.Mvc;

namespace FreelanceHub.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
