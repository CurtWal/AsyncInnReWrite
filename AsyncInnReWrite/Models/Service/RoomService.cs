using AsyncInnReWrite.Models.Service;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInnReWrite.Models.Interface;

namespace AsyncInnReWrite.Models.Service
{
    public class RoomService : IRoom
    {
        private readonly HotelDbContext _context;

        public RoomService(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }

        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var room = await _context.Rooms.ToListAsync();
            return room;
        }

        public async Task<Room> GetRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            return room;
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
