using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Midterm.Data;
using Midterm.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm.Controllers
{
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.Include(r => r.RoomType).ToListAsync();
            return View(rooms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var roomTypes = _context.RoomTypes.ToList();
            if (roomTypes == null || !roomTypes.Any())
            {
                ViewBag.RoomTypes = new SelectList(Enumerable.Empty<RoomType>(), "RoomTypeId", "RoomTypeName");
            }
            else
            {
                ViewBag.RoomTypes = new SelectList(roomTypes, "RoomTypeId", "RoomTypeName");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _context.Rooms.Add(room);
            int insert = await _context.SaveChangesAsync();
            if (insert == 0)
            {
                ModelState.AddModelError("", "Failed to save the room. Please try again.");
                return View(room);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            ViewBag.RoomTypes = _context.RoomTypes.ToList();
            return PartialView("_Edit", room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _context.Rooms.Update(room);
            int update = await _context.SaveChangesAsync();
            if (update == 0)
            {
                ModelState.AddModelError("", "Failed to update the room. Please try again.");
                return View(room);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(r => r.RoomId == id);

            if (room == null)
                return NotFound();

            return PartialView("_Detail", room);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            _context.Rooms.Remove(room);
            int delete = await _context.SaveChangesAsync();
            if (delete == 0)
            {
                ModelState.AddModelError("", "Failed to delete the room. Please try again.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
