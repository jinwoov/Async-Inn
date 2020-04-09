using AsyncInn.Data;
using AsyncInn.Models.DTO;
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
        private readonly IRoomManager _roomContext;

        public HotelRoomsService(AsyncInnDbContext context, IRoomManager roomContext)
        {
            _context = context;
            _roomContext = roomContext;
        }
        /// <summary>
        /// creating a hotel room by user given information
        /// </summary>
        /// <param name="hotelRooms">hotel room object</param>
        /// <returns></returns>
        public async Task<HotelRoomsDTO> CreateHotelRoom(HotelRooms hotelRooms)
        {
            HotelRoomsDTO dTO = new HotelRoomsDTO()
            {
                HotelID = hotelRooms.HotelID,
                RoomNumber = hotelRooms.RoomNumber,
                Rate = hotelRooms.Rate,
                PetFriendly = hotelRooms.PetFriendly,
                RoomID = hotelRooms.RoomID
            };

            _context.Add(hotelRooms);

            await _context.SaveChangesAsync();

            return dTO;
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
        public async Task<RoomDTO> GetByRoomNumber(int hotelID, int roomNumber)
        {
            var hotelRooms = await _context.HotelRoom.Where(x => x.RoomNumber == roomNumber && x.HotelID == hotelID)
                                               .SingleAsync();

             RoomDTO roomba = await _roomContext.GetRoom(hotelRooms.RoomID);

             return roomba;
        }

        /// <summary>
        /// Delegating hotel rooms to get the specific hotel room
        /// </summary>
        /// <param name="ID">specific hotel room</param>
        /// <returns>the specific hotel room</returns>
        public async Task<HotelRoomsDTO> GetHotelRoom(int ID, int roomNumber)
        {
            var hotelRoom = await _context.HotelRoom.Where(x => x.HotelID == ID && x.RoomNumber == roomNumber)
                                                    .SingleAsync();

            HotelRoomsDTO hRDTO = ConverToDTO(hotelRoom);

            RoomDTO room = await GetByRoomNumber(ID, roomNumber);

            hRDTO.Room = room;

            return hRDTO;
        }

        /// <summary>
        /// Method that will retrieve list of hotel rooms
        /// </summary>
        /// <returns>List of hotel rooms</returns>
        public async Task<List<HotelRoomsDTO>> GetHotelRooms()
        {
            var hotelRoom = await _context.HotelRoom.ToListAsync();

            List<HotelRoomsDTO> hotelList = new List<HotelRoomsDTO>();

            foreach (var hotel in hotelRoom)
            {
                HotelRoomsDTO dTO = new HotelRoomsDTO()
                {
                    HotelID = hotel.HotelID,
                    RoomNumber = hotel.RoomNumber,
                    Rate = hotel.Rate,
                    PetFriendly = hotel.PetFriendly,
                    RoomID = hotel.RoomID
                };
                hotelList.Add(dTO);
            }

            return hotelList;
        }

        /// <summary>
        /// Method that updates specific hotel room
        /// </summary>
        /// <param name="hotelRooms">hotel room object</param>
        public async Task UpdateHotelRoom(HotelRooms hotelRooms)
        {
            _context.Update(hotelRooms);

            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Converting our object to DTO object
        /// </summary>
        /// <param name="hotelRooms">hotelroom object</param>
        /// <returns>hotelroom DTO object</returns>
        public HotelRoomsDTO ConverToDTO(HotelRooms hotelRooms)
        {
                HotelRoomsDTO adto = new HotelRoomsDTO()
                {
                    HotelID = hotelRooms.HotelID,
                    RoomNumber = hotelRooms.RoomNumber,
                    Rate = hotelRooms.Rate,
                    PetFriendly = hotelRooms.PetFriendly,
                    RoomID = hotelRooms.RoomID
                };

            return adto;
        }
    }
}
