using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInnReWrite.Models
{
    public class RoomAmenities
    {
        public int Id { get; set; }
        public int AmenitiesID { get; set; }
        public int RoomID {get; set;}
        [ForeignKey("Amenity")]
        public ICollection<Amenity> Amenities { get; set; }
        public Room Room { get; set; }
    }
}
