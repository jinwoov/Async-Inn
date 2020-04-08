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

        //Read all hotelRooms
        Task<List<HotelRooms>> GetHotelRooms();

        // List of hotel rooms that are found using hotel id and room number
        Task<List<HotelRooms>> GetByRoomNumber(int hotelID, int roomNumber);

        //Update
        Task UpdateHotelRoom(HotelRooms hotelRooms);

        //Delete
        Task<HotelRooms> DeleteHotelRoom(int id);
    }
}
