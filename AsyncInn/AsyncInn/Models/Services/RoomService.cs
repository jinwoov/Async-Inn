using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{    /// <summary>
     /// This is to apply interface to the service
     /// </summary>
    public class RoomService : IRoomManager
    {
        private AsyncInnDbContext _context { get; }

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is to create a room in the database
        /// </summary>
        /// <param name="room">Room object that is being created</param>
        /// <returns>Object that's been created</returns>
        public async Task<Room> CreateRoom(Room room)
        {
            _context.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        /// <summary>
        /// Deleting existing room in our database
        /// </summary>
        /// <param name="ID">ID that the user chose</param>
        /// <returns>Room that has been deleted.</returns>
        public async Task<Room> DeleteRoom(int ID)
        {
            var room = await _context.Room.FindAsync(ID);
            _context.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        /// <summary>
        /// Delegating the Find Async method to occur using ansyncronous method of GetRoom
        /// </summary>
        /// <param name="ID">ID of the room</param>
        /// <returns>the specific room</returns>
        public async Task<Room> GetRoom(int ID) => await _context.Room.FindAsync(ID);

        /// <summary>
        /// Delegating the ToListAsync method to occur using ansyncronous method of GetRooms
        /// </summary>
        /// <returns>List of rooms</returns>
        public async Task<List<Room>> GetRooms() => await _context.Room.ToListAsync();

       /// <summary>
       /// This is to update an existing room
       /// </summary>
       /// <param name="room">Room object that is being passed in</param>
       /// <returns></returns>
        public async Task UpdateRoom(Room room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
