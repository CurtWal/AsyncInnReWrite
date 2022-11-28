using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInnReWrite.Models;
using Hotel.Data;

namespace AsyncInnReWrite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRooomsController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public HotelRooomsController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelRoooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRooom>>> GetHotelRoom()
        {
            return await _context.HotelRoom.ToListAsync();
        }

        // GET: api/HotelRoooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRooom>> GetHotelRooom(int id)
        {
            var hotelRooom = await _context.HotelRoom.FindAsync(id);

            if (hotelRooom == null)
            {
                return NotFound();
            }

            return hotelRooom;
        }

        // PUT: api/HotelRoooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRooom(int id, HotelRooom hotelRooom)
        {
            if (id != hotelRooom.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelRooom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRooomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HotelRoooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRooom>> PostHotelRooom(HotelRooom hotelRooom)
        {
            _context.HotelRoom.Add(hotelRooom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelRooom", new { id = hotelRooom.Id }, hotelRooom);
        }

        // DELETE: api/HotelRoooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRooom(int id)
        {
            var hotelRooom = await _context.HotelRoom.FindAsync(id);
            if (hotelRooom == null)
            {
                return NotFound();
            }

            _context.HotelRoom.Remove(hotelRooom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelRooomExists(int id)
        {
            return _context.HotelRoom.Any(e => e.Id == id);
        }
    }
}
