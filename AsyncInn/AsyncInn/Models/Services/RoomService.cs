using AsyncInn.Data;
using AsyncInn.Models.DTO;
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
        public async Task<RoomDTO> CreateRoom(Room room)
        {
            var roomDTO = ConvertToDTO(room);

            _context.Add(room);

            await _context.SaveChangesAsync();

            return roomDTO;
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
        public async Task<RoomDTO> GetRoom(int ID)
        {
            Room room = await _context.Room.FindAsync(ID);
            return ConvertToDTO(room);
        }

        /// <summary>
        /// Delegating the ToListAsync method to occur using ansyncronous method of GetRooms
        /// </summary>
        /// <returns>List of rooms</returns>
        public async Task<List<RoomDTO>> GetRooms()
        {
            var rooms = await _context.Room.ToListAsync();

            List<RoomDTO> adto = new List<RoomDTO>();

            foreach (var item in rooms)
            {
                RoomDTO dTO = new RoomDTO()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Layout = item.Layout.ToString()
                };
                adto.Add(dTO);
            }

            return adto;
        }
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

        public async Task<List<RoomAmenities>> AmenitiesByRoomID(int ID)
        {
            var amenities = await _context.RoomAmenities.Where(x => x.RoomID == ID)
                                                  .Include(x => x.Amenities)
                                                  .ToListAsync();
            return amenities;
        }

        public RoomDTO ConvertToDTO(Room room)
        {
            RoomDTO adto = new RoomDTO()
            {
                Name = room.Name,
                ID = room.ID,
                Layout = room.Layout.ToString()
            };
            return adto;
        }

    }
}
