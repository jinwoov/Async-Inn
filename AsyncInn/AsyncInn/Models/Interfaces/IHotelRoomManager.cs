using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoomManager
    {
        //Create
        Task<HotelRoomsDTO> CreateHotelRoom(HotelRooms hotelRooms);

        //Read
        Task<List<HotelRoomsDTO>> GetHotelRoom(int ID);

        //Read all hotelRooms
        Task<List<HotelRoomsDTO>> GetHotelRooms();

        // List of hotel rooms that are found using hotel id and room number
        Task<RoomDTO> GetByRoomNumber(int hotelID, int roomNumber);

        //Update
        Task UpdateHotelRoom(HotelRooms hotelRooms);

        //Delete
        Task<HotelRooms> DeleteHotelRoom(int id);
    }
}
