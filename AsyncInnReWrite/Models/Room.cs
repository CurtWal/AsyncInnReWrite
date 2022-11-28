using Microsoft.EntityFrameworkCore;

namespace AsyncInnReWrite.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }


        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
