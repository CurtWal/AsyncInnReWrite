using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInnReWrite.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        [DisplayName("Amenity")]
        public string Name { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
