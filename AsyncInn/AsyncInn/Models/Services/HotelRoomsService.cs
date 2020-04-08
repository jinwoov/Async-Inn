using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelRoomsService : IHotelRoomManager
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomsService(AsyncInnDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// creating a hotel room by user given information
        /// </summary>
        /// <param name="hotelRooms">hotel room object</param>
        /// <returns></returns>
        public async Task<HotelRooms> CreateHotelRoom(HotelRooms hotelRooms)
        {
            _context.Add(hotelRooms);

            await _context.SaveChangesAsync();

            return hotelRooms;
        }
        /// <summary>
        /// Deleting Hotel Room depending on user's choice
        /// </summary>
        /// <param name="id">Id of room that user wants to delete</param>
        /// <returns>hotel room that has been deleted</returns>
        public async Task<HotelRooms> DeleteHotelRoom(int id)
        {
            var hotelRoom = await _context.HotelRoom.FindAsync(id);

            _context.Remove(hotelRoom);

            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        /// <summary>
        /// Get the hotelroom by its hotel id and roomnumber
        /// </summary>
        /// <param name="hotelID">id of hotel</param>
        /// <param name="roomNumber">room number that was given</param>
        /// <returns>list of hotel rooms</returns>
        public async Task<List<HotelRooms>> GetByRoomNumber(int hotelID, int roomNumber)
        {
            var hotelRooms = await _context.HotelRoom.Where(x => x.RoomNumber == roomNumber && x.HotelID == hotelID)
                                               .Select(x => x)
                                               .ToListAsync();

            return hotelRooms;
        }

        /// <summary>
        /// Delegating hotel rooms to get the specific hotel room
        /// </summary>
        /// <param name="ID">specific hotel room</param>
        /// <returns>the specific hotel room</returns>
        public async Task<HotelRooms> GetHotelRoom(int ID) => await _context.HotelRoom.FindAsync(ID);

        /// <summary>
        /// Method that will retrieve list of hotel rooms
        /// </summary>
        /// <returns>List of hotel rooms</returns>
        public async Task<List<HotelRooms>> GetHotelRooms() => await _context.HotelRoom.ToListAsync();

        /// <summary>
        /// Method that updates specific hotel room
        /// </summary>
        /// <param name="hotelRooms">hotel room object</param>
        public async Task UpdateHotelRoom(HotelRooms hotelRooms)
        {
            _context.Update(hotelRooms);

            await _context.SaveChangesAsync();
        }
    }
}
