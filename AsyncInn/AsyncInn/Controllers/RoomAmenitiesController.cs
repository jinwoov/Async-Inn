using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    [Route("api/room/amenities")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        /// This is DbContext object that is created when the this route is called
        private readonly AsyncInnDbContext _context;

        /// assigning the Dbcontext context to private context property
        public RoomAmenitiesController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // POST: api/RoomAmenities
        // Creates new RoomAmenities when user input information
        [HttpPost, Route("{roomId}/{amenitiesId}")]
        public async Task<ActionResult<RoomAmenities>> PostRoomAmenities(RoomAmenities roomAmenities)
        {
            _context.RoomAmenities.Add(roomAmenities);
                await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomAmenities", new { id = roomAmenities.AmenitiesID }, roomAmenities);
        }

        // DELETE: api/RoomAmenities/5
        //Deletes specific id that is in RoomAmenities database
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomAmenities>> DeleteRoomAmenities(string id)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();

            return roomAmenities;
        }
  
    }
}
