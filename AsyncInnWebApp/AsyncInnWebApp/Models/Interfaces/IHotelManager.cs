using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnWebApp.Models.Interfaces
{
    public interface IHotelManager
    {
        //Getting all the hotels
        Task<List<Hotel>> GetAllHotels();
        //Getting single hotel by ID
        Task<Hotel> GetHotelByID(int ID);
    }
}
