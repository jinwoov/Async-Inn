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
        Task<HotelRoomsDTO> GetHotelRoom(int ID, int roomNumber);

        //Read all hotelRooms
        Task<List<HotelRoomsDTO>> GetHotelRooms();

        //Update
        Task UpdateHotelRoom(HotelRooms hotelRooms);

        //Delete
        Task<HotelRooms> DeleteHotelRoom(int id);
    }
}
