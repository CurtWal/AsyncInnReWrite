namespace AsyncInnReWrite.Models.DTO
{
    public class AmenityDTO
    {
        public string Name { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
