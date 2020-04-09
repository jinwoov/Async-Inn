using AsyncInn.Data;
using AsyncInn.Models.DTO;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{   //Bring in the interface
    public class HotelService : IHotelManager
    {   //The below assigns DbContext object to a object that is residing within HotelService
        public HotelService(AsyncInnDbContext context, IHotelRoomManager roomContext)
        {
            _context = context;
            _roomContext = roomContext;
        }

        //The below is the private property that will access the database
        private AsyncInnDbContext _context { get; }
        private IHotelRoomManager _roomContext { get; }

        //The below method will Create a new hotel.
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        //The below method will Delete a hotel.
        public async Task<Hotel> DeleteHotel(int ID)
        {
            var hotel = await _context.Hotel.FindAsync(ID);
            _context.Remove(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        //The below method will get one specific hotel.
        public async Task<Hotel> GetHotel(int ID)
        {
            var hotels = await _context.Hotel.FindAsync(ID);
            return hotels;

        }

        //The below method will get all hotels.
        public async Task<List<Hotel>> GetHotels() => await _context.Hotel.ToListAsync();

        public async Task<List<HotelRoomsDTO>> GetRoomsByHotelID(int ID)
        {
            var hotelRooms = await _context.HotelRoom.Where(x => x.HotelID == ID)
                                                     .Include(r => r.RoomID)
                                                     .ToListAsync();

            List<HotelRoomsDTO> rooms = new List<HotelRoomsDTO>();

            //foreach (var room in hotelRooms)
            //{
            //    HotelRoomsDTO roomba = await _roomContext.GetHotelRoom(room.RoomID);
            //    rooms.Add(roomba);
            //}

            return rooms;
        }

        //The below method will update a specific hotel.
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
