using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoomManager
    {
        //Create
        Task<HotelRooms> CreateHotelRoom(HotelRooms hotelRooms);

        //Read
        Task<HotelRooms> GetHotelRoom(int ID);

        //Read all amenities
        Task<List<HotelRooms>> GetHotelRooms();

        //Update
        Task UpdateHotelRoom(HotelRooms hotelRooms);

        //Delete
        Task<HotelRooms> DeleteHotelRoom(int id);
    }
}
