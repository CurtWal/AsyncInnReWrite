using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInnReWrite.Models
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        [ForeignKey("Hotel")]
        public int HotelID { get; set; }
        public Hotels Hotel { get; set; }
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
