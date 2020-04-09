using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        //Create
        Task<RoomDTO> CreateRoom(Room room);

        //Read
        Task<RoomDTO> GetRoom(int ID);

        //Read All
        Task<List<RoomDTO>> GetRooms();

        //Update
        Task UpdateRoom(Room room);

        //Delete
        Task<Room> DeleteRoom(int ID);

        //The below will grab all the amenities inside RoomAmenities
        Task<List<AmenitiesDTO>> AmenitiesByRoomID(int ID);

    }
}
