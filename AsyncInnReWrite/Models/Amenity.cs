using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInnReWrite.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Room Amenities")]
        public ICollection<RoomAmenities> roomAmenities { get; set; }
    }
}
