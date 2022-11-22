namespace AsyncInnReWrite.Models.Interface
{
    public interface IAmenity
    {
        //Create
        Task<Amenity> Create(Amenity amenities);

        //Get All
        Task<List<Amenity>> GetAmenities();

        //Get by Id
        Task<Amenity> GetAmenity(int id);

        //Update
        Task<Amenity> UpdateAmenity(int id, Amenity amenities);
        //Delete
        Task Delete(int id);
    }
}
