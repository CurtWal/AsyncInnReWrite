﻿namespace AsyncInnReWrite.Models.DTO
{
    public class RoomDTO
    {
        public string Name { get; set; }
        public string Layout { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }

    }
}
