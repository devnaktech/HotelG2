using Microsoft.AspNetCore.Mvc;

namespace HotelG2.Controllers
{
    public class Customer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
