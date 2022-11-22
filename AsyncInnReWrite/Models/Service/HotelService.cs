using Hotel.Data;
using AsyncInnReWrite.Models.Interface;
using AsyncInnReWrite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models.Services
{
    public class HotelService : IHotel
    {
        private readonly HotelDbContext _context;

        public HotelService(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }

        public async Task<Hotels> Create(Hotels hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task<List<Hotels>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotels> GetHotel(int id)
        {
            Hotels hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        public async Task<Hotels> UpdateHotel(int id, Hotels hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotels hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}