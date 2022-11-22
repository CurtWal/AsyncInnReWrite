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

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsyncInnReWrite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _context;

        public AmenitiesController(IAmenity c)
        {
            _context = c;
        }

        // GET: api/Amenities
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            // You should count the list ...
            var list = await _context.GetAmenities();
            return Ok(list);
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            Amenity amenities = await _context.GetAmenity(id);
            return amenities;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Create(int id, Amenity amenities)
        {
            if (id != amenities.Id)
            {
                return BadRequest();
            }

            var updatedAmenity = await _context.UpdateAmenity(id, amenities);

            return Ok(updatedAmenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<Amenity>> UpdateAmenity(Amenity amenities)
        {
            await _context.Create(amenities);

            // Return a 201 Header to browser
            // The body of the request will be us running GetTechnology(id);
            return CreatedAtAction("GetAmenitie", new { id = amenities.Id }, amenities);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _context.Delete(id);
            return NoContent();
        }
    }
}
