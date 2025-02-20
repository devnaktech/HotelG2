using Microsoft.AspNetCore.Mvc;

namespace HotelG2.Controllers; 

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
