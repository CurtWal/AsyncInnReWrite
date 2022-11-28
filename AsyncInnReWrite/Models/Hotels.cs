using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace AsyncInnReWrite.Models
{
    public class Hotels
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string Address { get; set;}
        public string City { get; set;}
        public string State { get; set;}
        public string Country { get; set;}
        public string PhoneNum { get; set;}

        public ICollection<HotelRooom> HotelRoom { get; set;}

    }
}
