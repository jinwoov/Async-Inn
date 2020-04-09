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
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        /// This is DbContext object that is created when the this route is called
        private readonly IRoomManager _context;

        /// assigning the Dbcontext context to private context property
        public RoomsController(IRoomManager context)
        {
            _context = context;
        }

        // GET: api/Rooms
        // Get route that is shows list of Room in the method
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRoom() => await _context.GetRooms();

        // GET: api/Rooms/5
        /// Get route that shows specific Room when user picks
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _context.GetRoom(id);


            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // Update method that checks for the ID and change if it does exist otherwise returns bad request
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            try
            {
                await _context.UpdateRoom(room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rooms
        // Creates new Rooms when user input information
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> PostRoom(Room room)
        {
            var newRoom = await _context.CreateRoom(room);

            return CreatedAtAction("GetRoom", new { id = newRoom.ID }, newRoom);
        }

        // DELETE: api/Rooms/5
        //Deletes specific id that is in Room database
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            return await _context.DeleteRoom(id);
        }

        /// checks if the Room id exists in the database
        private async Task<bool> RoomExists(int id)
        {
            RoomDTO room = await _context.GetRoom(id);
            return room != null ? true : false;
        }
    }
}
