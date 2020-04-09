using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTO;

namespace AsyncInn.Controllers
{
    [Route("api/hotel/room")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        /// This is DbContext object that is created when the this route is called
        private readonly IHotelRoomManager _context;

        /// assigning the Dbcontext context to private context property
        public HotelRoomsController(IHotelRoomManager context)
        {
            _context = context;
        }

        // GET: api/HotelRooms
        /// Get route that is shows list of HotelRooms in the method
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomsDTO>>> GetHotelRoom() => await _context.GetHotelRooms();


        // GET: api/HotelRooms/5
        /// Get route that shows specific HotelRooms when user picks
        [HttpGet, Route("{hotelId}/{roomNumber}")]
        public async Task<ActionResult<HotelRoomsDTO>> GetHotelRooms(int hotelId, int roomNumber)
        {
            var hotelRooms = await _context.GetHotelRoom(hotelId, roomNumber);

            if (hotelRooms == null)
            {
                return NotFound();
            }

            return hotelRooms;
        }

        // PUT: api/HotelRooms/5
        // Update method that checks for the ID and change if it does exist otherwise return bad request
        [HttpPut, Route("{hotelId}/{roomNumber}")]
        public async Task<IActionResult> PutHotelRooms(int hotelId, HotelRooms hotelRooms)
        {
            if (hotelId != hotelRooms.HotelID)
            {
                return BadRequest();
            }

            await _context.UpdateHotelRoom(hotelRooms);
           

            return NoContent();
        }

        // POST: api/HotelRooms
        // Creates new HotelRooms when user input information
        [HttpPost]
        public async Task<ActionResult<HotelRooms>> PostHotelRooms(HotelRooms hotelRooms)
        {
            var newHotelrooms = await _context.CreateHotelRoom(hotelRooms);

            return CreatedAtAction("GetHotelRooms", new { id = newHotelrooms.HotelID }, newHotelrooms);
        }

        // DELETE: api/HotelRooms/5
        //Deletes specific id that is in HotelRooms database
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRooms>> DeleteHotelRooms(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            return await _context.DeleteHotelRoom(id);
        }

        ///// checks if the HotelRooms id exists in the database
        //private async Task<bool> HotelRoomsExists(int id)
        //{
        //    HotelRoomsDTO hotelRooms = await _context.GetHotelRoom(id);
        //    return hotelRooms != null ? true : false;
        //}
    }
}
