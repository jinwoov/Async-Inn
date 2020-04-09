using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        //Create
        Task<Hotel> CreateHotel(Hotel hotel);

        //Read
        Task<HotelDTO> GetHotel(int ID);

        //Read All
        Task<List<HotelDTO>> GetHotels();

        //Update
        Task UpdateHotel(Hotel hotel);

        //Delete
        Task<Hotel> DeleteHotel(int ID);

        //The below connects Hotel Rooms to Rooms by a join table. 
        Task<List<HotelRoomsDTO>> GetRoomsByHotelID(int ID);
    }
}
