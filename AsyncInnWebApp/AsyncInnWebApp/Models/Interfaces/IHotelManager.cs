using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnWebApp.Models.Interfaces
{
    public interface IHotelManager
    {
        Task<List<Hotel>> GetAllHotels();

        Task<Hotel> GetHotelByID(int ID);
    }
}
