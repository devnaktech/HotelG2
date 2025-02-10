using Microsoft.AspNetCore.Mvc;

namespace LMC103.Controllers; 

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
