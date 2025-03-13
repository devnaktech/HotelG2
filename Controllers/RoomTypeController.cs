using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Midterm.Data;
using Midterm.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly AppDbContext _context;

        public RoomTypeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var roomTypes = await _context.RoomTypes.ToListAsync();
            return View(roomTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomType roomType)
        {
            if (!ModelState.IsValid)
                return View(roomType);

            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
                return NotFound();

            return View(roomType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomType roomType)
        {
            if (!ModelState.IsValid)
                return View(roomType);

            _context.RoomTypes.Update(roomType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
                return NotFound();

            return View(roomType);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
                return NotFound();

            try
            {
                _context.RoomTypes.Remove(roomType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Cannot delete Room Type because it is linked to rooms.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
