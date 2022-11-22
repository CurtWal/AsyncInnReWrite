
namespace AsyncInnReWrite.Models.Interface
{
    public interface IRoom
    {
        Task<Room> Create(Room room);

        //Get All
        Task<List<Room>> GetRooms();

        //Get by Id
        Task<Room> GetRoom(int id);

        //Update
        Task<Room> UpdateRoom(int id, Room room);

        //Delete
        Task Delete(int id);
    }
}
