
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AsyncInnReWrite.Models.Interface
{
    public interface IHotel
    {
        //Create
        Task<Hotels> Create(Hotels hotels);

        //Get All
        Task<List<Hotels>> GetHotels();

        //Get by Id
        Task<Hotels> GetHotel(int id);

        //Update
        Task<Hotels> UpdateHotel(int id, Hotels hotel);
        //Delete
        Task Delete(int id);
    }
}
