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
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _context;

        
        public RoomsController(IRoom c)
        {
            _context = c;
        }

        // GET: api/Rooms
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            // You should count the list ...
            var list = await _context.GetRooms();
            return Ok(list);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            Room room = await _context.GetRoom(id);
            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        

        public async Task<IActionResult> Create(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var updatedRoom = await _context.UpdateRoom(id, room);

            return Ok(updatedRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public async Task<ActionResult<Room>> UpdateRoom(Room room)
        {
            await _context.Create(room);

            // Return a 201 Header to browser
            // The body of the request will be us running GetTechnology(id);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            await _context.Delete(id);
            return NoContent();
        }
    }
}