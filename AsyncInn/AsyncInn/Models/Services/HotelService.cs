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
        public async Task<HotelDTO> CreateHotel(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
            HotelDTO hdto = ConvertToDTO(hotel);
            return hdto;
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
        public async Task<HotelDTO> GetHotel(int ID)
        {
            var hotels = await _context.Hotel.FindAsync(ID);
            HotelDTO hDTO = ConvertToDTO(hotels);
            hDTO.Rooms = await GetRoomsByHotelID(ID);
            return hDTO;

        }

        //The below method will get all hotels.
        public async Task<List<HotelDTO>> GetHotels()
        {
            List<Hotel> hotel = await _context.Hotel.ToListAsync();
            List<HotelDTO> hDTO = new List<HotelDTO>();
            foreach (var item in hotel)
            {
                HotelDTO aDTO = ConvertToDTO(item);
                hDTO.Add(aDTO);
            }
            return hDTO;
        }

        /// <summary>
        /// Getting the hotel room data using the hotel ID 
        /// </summary>
        /// <param name="ID">ID of hotel</param>
        /// <returns>List of hotel room DTO</returns>
        public async Task<List<HotelRoomsDTO>> GetRoomsByHotelID(int ID)
        {
            var hotelRooms = await _context.HotelRoom.Where(x => x.HotelID == ID)
                                                     .ToListAsync();

            List<HotelRoomsDTO> rooms = new List<HotelRoomsDTO>();

            foreach (var room in hotelRooms)
            {
                HotelRoomsDTO roomba = await _roomContext.GetHotelRoom(room.HotelID, room.RoomNumber);
                rooms.Add(roomba);
            }

            return rooms;
        }

        //The below method will update a specific hotel.
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Converting the hotel object to DTO object
        /// </summary>
        /// <param name="hotel">hotel object that is being passed in</param>
        /// <returns>hotel DTO object</returns>
        public HotelDTO ConvertToDTO(Hotel hotel)
        {
            HotelDTO hDTO = new HotelDTO()
            {
                ID = hotel.ID,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone
            };
            return hDTO;
        }
            
    }
}
