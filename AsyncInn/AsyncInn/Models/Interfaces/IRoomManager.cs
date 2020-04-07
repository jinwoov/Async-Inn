using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        //Create
        Task<Room> CreateRoom(Room room);

        //Read
        Task<Room> GetRoom(int ID);

        //Read All
        Task<List<Room>> GetRooms();

        //Update
        Task UpdateRoom(Room room);

        //Delete
        Task<Room> DeleteRoom(int ID);
    }
}
