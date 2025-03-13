using Microsoft.AspNetCore.Mvc;

namespace Midterm.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return RedirectToAction("Login", "Account");
    }
  }
}
