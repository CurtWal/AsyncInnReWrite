using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using AsyncInnReWrite.Models;
using AsyncInnReWrite.Models.Interface;


namespace AsyncInnReWrite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _context;
        
        public HotelsController(IHotel c)
        {
            _context = c;
        }

        // GET: api/Hotels
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Hotels>>> GetHotels()
        {
            // You should count the list ...
            var list = await _context.GetHotels();
            return Ok(list);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
       
        public async Task<ActionResult<Hotels>> GetHotel(int id)
        {
            Hotels hotel = await _context.GetHotel(id);
            return hotel;
        }


        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Create(int id, Hotels hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            var updatedHotel = await _context.UpdateHotel(id, hotel);

            return Ok(updatedHotel);
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotels>> UpdateHotel(Hotels hotel)
        {
            await _context.Create(hotel);

            // Return a 201 Header to browser
            // The body of the request will be us running GetTechnology(id);
            return CreatedAtAction("GetInn", new { id = hotel.Id }, hotel);
        }


        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _context.Delete(id);
            return NoContent();
        }
    }
}