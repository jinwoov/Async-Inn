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
    [Route("api/[controller]")]
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

        // GET: api/RoomAmenities
        /// Get route that is shows list of RoomAmenities in the method
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenities>>> GetRoomAmenities()
        {
            return await _context.RoomAmenities.ToListAsync();
        }

        // GET: api/RoomAmenities/5
        /// Get route that shows specific RoomAmenities when user picks
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomAmenities>> GetRoomAmenities(string id)
        {
            var roomAmenities = await _context.RoomAmenities.FindAsync(id);

            if (roomAmenities == null)
            {
                return NotFound();
            }

            return roomAmenities;
        }

        // PUT: api/RoomAmenities/5
        // Update method that checks for the ID and change if it does exist otherwise returns bad request
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomAmenities(string id, RoomAmenities roomAmenities)
        {
            if (id != roomAmenities.AmenitiesID)
            {
                return BadRequest();
            }

            _context.Entry(roomAmenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomAmenitiesExists(id))
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

        // POST: api/RoomAmenities
        // Creates new RoomAmenities when user input information
        [HttpPost]
        public async Task<ActionResult<RoomAmenities>> PostRoomAmenities(RoomAmenities roomAmenities)
        {
            _context.RoomAmenities.Add(roomAmenities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomAmenitiesExists(roomAmenities.AmenitiesID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

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

        /// checks if the RoomAmenities id exists in the database
        private bool RoomAmenitiesExists(string id)
        {
            return _context.RoomAmenities.Any(e => e.AmenitiesID == id);
        }
    }
}
