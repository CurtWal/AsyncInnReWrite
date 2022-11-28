using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInnReWrite.Models.DTO;
using Hotel.Data;
using AsyncInnReWrite.Models;

namespace AsyncInnReWrite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDTOesController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public UserDTOesController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO data)
        {
            var user = await ApplicationUser.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO data)
        {
            var user = await ApplicationUser.Authenticate(data.UserName, data.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        // GET: api/UserDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserDTO()
        {
            return await _context.UserDTO.ToListAsync();
        }

        // GET: api/UserDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserDTO(string id)
        {
            var userDTO = await _context.UserDTO.FindAsync(id);

            if (userDTO == null)
            {
                return NotFound();
            }

            return userDTO;
        }

        // PUT: api/UserDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDTO(string id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDTOExists(id))
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

        // POST: api/UserDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUserDTO(UserDTO userDTO)
        {
            _context.UserDTO.Add(userDTO);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserDTOExists(userDTO.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserDTO", new { id = userDTO.Id }, userDTO);
        }

        // DELETE: api/UserDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDTO(string id)
        {
            var userDTO = await _context.UserDTO.FindAsync(id);
            if (userDTO == null)
            {
                return NotFound();
            }

            _context.UserDTO.Remove(userDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDTOExists(string id)
        {
            return _context.UserDTO.Any(e => e.Id == id);
        }
    }
}
