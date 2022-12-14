using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInnReWrite.Models;
using Hotel.Data;
using AsyncInnReWrite.Models.DTO;
using AsyncInnReWrite.Models.Interface;

namespace AsyncInnReWrite.Controllers.Web
{
    public class AmenitiesController : Controller
    {
        private readonly HotelDbContext _context;

        public AmenitiesController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index()
        {
              return View(await _context.Amenities.ToListAsync());
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Amenities == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenities.Include(r => r.RoomAmenities).ThenInclude(ra => ra.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amenity == null)
            {
                return NotFound();
            }
            AmenityDTO roomAmen = new AmenityDTO() { Name = amenity.Name, RoomAmenities = amenity.RoomAmenities };
            return View(roomAmen);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Amenity amenity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amenity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenity);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Amenities == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return View(amenity);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityExists(amenity.Id))
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
            return View(amenity);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Amenities == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Amenities == null)
            {
                return Problem("Entity set 'HotelDbContext.Amenities'  is null.");
            }
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity != null)
            {
                _context.Amenities.Remove(amenity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityExists(int id)
        {
          return _context.Amenities.Any(e => e.Id == id);
        }
    }
}
