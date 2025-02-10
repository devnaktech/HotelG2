using Microsoft.AspNetCore.Mvc;

namespace LMC103.Controllers
{
    public class Customer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
