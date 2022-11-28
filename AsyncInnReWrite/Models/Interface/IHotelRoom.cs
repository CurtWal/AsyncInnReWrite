namespace AsyncInnReWrite.Models.Interface
{
    public interface IHotelRoom
    {
        //Create
        Task<HotelRooom> Create(HotelRooom hotelroom);

        //Get All
        Task<List<HotelRooom>> GetHotelRooms();

        //Get by Id
        Task<HotelRooom> GetHotelRoom(int id);

        //Update
        Task<HotelRooom> UpdateHotelRoom(int id, HotelRooom hotelroom);
        //Delete
        Task Delete(int id);
    }
}
