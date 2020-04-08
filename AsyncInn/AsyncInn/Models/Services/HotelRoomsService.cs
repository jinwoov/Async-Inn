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

        public async Task<HotelRooms> DeleteHotelRoom(int id)
        {
            var hotelRoom = await _context.HotelRoom.FindAsync(id);

            _context.Remove(hotelRoom);

            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        public async Task<HotelRooms> GetHotelRoom(int ID) => await _context.HotelRoom.FindAsync(ID);

        public async Task<List<HotelRooms>> GetHotelRooms() => await _context.HotelRoom.ToListAsync();

        public async Task UpdateHotelRoom(HotelRooms hotelRooms)
        {
            _context.Update(hotelRooms);

            await _context.SaveChangesAsync();
        }
    }
}
