using HotelG2.Date;
using HotelG2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMC103.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var depts = _context.Departments.ToList();
            return View(depts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Department", "Description")] Department dept)
        {
            _context.Departments.Add(dept);

            int insteredRows = _context.SaveChanges();

            return insteredRows > 0 ? RedirectToAction(nameof(Index)) : View(dept);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept is null)
            {
                return NotFound();
            }
            return View("Edit", dept);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department dept)
        {
            _context.Departments.Update(dept);
            int insteredRows = _context.SaveChanges();
            return insteredRows > 0 ? RedirectToAction(nameof(Index)) : View(dept);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept is null) return NotFound();
            return View("Details", dept);
        }
    }
}
