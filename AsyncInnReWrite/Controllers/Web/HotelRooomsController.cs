using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInnReWrite.Models;
using Hotel.Data;

namespace AsyncInnReWrite.Controllers.Web
{
    public class HotelRooomsController : Controller
    {
        private readonly HotelDbContext _context;

        public HotelRooomsController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: HotelRoooms
        public async Task<IActionResult> Index()
        {
            var hotelDbContext = _context.HotelRoom.Include(h => h.Hotel).Include(h => h.Room);
            return View(await hotelDbContext.ToListAsync());
        }

        // GET: HotelRoooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HotelRoom == null)
            {
                return NotFound();
            }

            var hotelRooom = await _context.HotelRoom
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelRooom == null)
            {
                return NotFound();
            }

            return View(hotelRooom);
        }

        // GET: HotelRoooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "Id", "Id");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "Id", "Id");
            return View();
        }

        // POST: HotelRoooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomNumber,Rate,PetFriendly,HotelID,RoomID")] HotelRooom hotelRooom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRooom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "Id", "Id", hotelRooom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "Id", "Id", hotelRooom.RoomID);
            return View(hotelRooom);
        }

        // GET: HotelRoooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HotelRoom == null)
            {
                return NotFound();
            }

            var hotelRooom = await _context.HotelRoom.FindAsync(id);
            if (hotelRooom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "Id", "Id", hotelRooom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "Id", "Id", hotelRooom.RoomID);
            return View(hotelRooom);
        }

        // POST: HotelRoooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomNumber,Rate,PetFriendly,HotelID,RoomID")] HotelRooom hotelRooom)
        {
            if (id != hotelRooom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRooom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRooomExists(hotelRooom.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "Id", "Id", hotelRooom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "Id", "Id", hotelRooom.RoomID);
            return View(hotelRooom);
        }

        // GET: HotelRoooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HotelRoom == null)
            {
                return NotFound();
            }

            var hotelRooom = await _context.HotelRoom
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelRooom == null)
            {
                return NotFound();
            }

            return View(hotelRooom);
        }

        // POST: HotelRoooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HotelRoom == null)
            {
                return Problem("Entity set 'HotelDbContext.HotelRoom'  is null.");
            }
            var hotelRooom = await _context.HotelRoom.FindAsync(id);
            if (hotelRooom != null)
            {
                _context.HotelRoom.Remove(hotelRooom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRooomExists(int id)
        {
          return _context.HotelRoom.Any(e => e.Id == id);
        }
    }
}
