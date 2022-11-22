using AsyncInnReWrite.Models.Interface;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInnReWrite.Models.Service
{
    public class AmenityService : IAmenity
    {
        private readonly HotelDbContext _context;

        public AmenityService(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }

        public async Task<Amenity> Create(Amenity amenities)
        {
            _context.Entry(amenities).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return amenities;
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenity = await _context.Amenities.ToListAsync();
            return amenity;
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenities = await _context.Amenities.FindAsync(id);
            return amenities;
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task Delete(int id)
        {
            Amenity amenities = await GetAmenity(id);
            _context.Entry(amenities).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
