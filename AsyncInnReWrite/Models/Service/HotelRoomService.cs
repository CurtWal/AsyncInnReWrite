using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInnReWrite.Models.Interface;


namespace AsyncInnReWrite.Models.Service
{
    public class HotelRoomService : IHotelRoom
    {
        private readonly HotelDbContext _context;

        public HotelRoomService(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }

        public async Task<HotelRooom> Create(HotelRooom hotelroom)
        {
            _context.Entry(hotelroom).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return hotelroom;
        }

        public async Task<List<HotelRooom>> GetHotelRooms()
        {
            var hotelrooms = await _context.HotelRoom.ToListAsync();
            return hotelrooms;
        }

        public async Task<HotelRooom> GetHotelRoom(int id)
        {
            HotelRooom hotelroom = await _context.HotelRoom.FindAsync(id);
            return hotelroom;
        }

        public async Task<HotelRooom> UpdateHotelRoom(int id, HotelRooom hotelroom)
        {
            _context.Entry(hotelroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelroom;
        }

        public async Task Delete(int id)
        {
            HotelRooom hotelroom = await GetHotelRoom(id);
            _context.Entry(hotelroom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
