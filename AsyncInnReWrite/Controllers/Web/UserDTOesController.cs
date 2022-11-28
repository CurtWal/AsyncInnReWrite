using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInnReWrite.Models.DTO;
using Hotel.Data;
using AsyncInnReWrite.Models;

namespace AsyncInnReWrite.Controllers.Web
{
    public class UserDTOesController : Controller
    {
        private readonly HotelDbContext _context;

        public UserDTOesController(HotelDbContext context)
        {
            _context = context;
        }
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterUserDTO newUser)
        {
            return RedirectToRoute("api/UsersDTOes/Register", newUser);
        }
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO rUser)
        {
            return RedirectToRoute("api/UserDTOes/Login", rUser);
        }
        // GET: UserDTOes
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserDTO.ToListAsync());
        }

        // GET: UserDTOes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserDTO == null)
            {
                return NotFound();
            }

            var userDTO = await _context.UserDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDTO == null)
            {
                return NotFound();
            }

            return View(userDTO);
        }

        // GET: UserDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username")] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDTO);
        }

        // GET: UserDTOes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserDTO == null)
            {
                return NotFound();
            }

            var userDTO = await _context.UserDTO.FindAsync(id);
            if (userDTO == null)
            {
                return NotFound();
            }
            return View(userDTO);
        }

        // POST: UserDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Username")] UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDTOExists(userDTO.Id))
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
            return View(userDTO);
        }

        // GET: UserDTOes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserDTO == null)
            {
                return NotFound();
            }

            var userDTO = await _context.UserDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDTO == null)
            {
                return NotFound();
            }

            return View(userDTO);
        }

        // POST: UserDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserDTO == null)
            {
                return Problem("Entity set 'HotelDbContext.UserDTO'  is null.");
            }
            var userDTO = await _context.UserDTO.FindAsync(id);
            if (userDTO != null)
            {
                _context.UserDTO.Remove(userDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDTOExists(string id)
        {
          return _context.UserDTO.Any(e => e.Id == id);
        }
    }
}
