using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInnReWrite.Models
{
    public class RoomAmenities
    {
        public int Id { get; set; }
        [ForeignKey("Amenity")]
        public int AmenitiesID { get; set; }
        [ForeignKey("Room")]
        public int RoomID {get; set;}
        public Amenity Amenities { get; set; }
        public Room Room { get; set; }
    }
}
