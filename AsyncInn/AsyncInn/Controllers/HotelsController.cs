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

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        /// This is DbContext object that is created when the this route is called
        private readonly IHotelManager _context;

        /// assigning the Dbcontext context to private context property
        public HotelsController(IHotelManager context)
        {
            _context = context;
        }

        // GET: api/Hotels
        /// Get route that is shows list of Hotel in the method
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel() => await _context.GetHotels();

        // GET: api/Hotels/5
        /// Get route that shows specific Hotel when user picks
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // Update method that checks for the ID and change if it does exist otherwise return bad request
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }

            try
            {
                await _context.UpdateHotel(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        // Creates new Hotel when user input information
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            var NewHotel = await _context.CreateHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = NewHotel.ID }, NewHotel);
        }

        // DELETE: api/Hotels/5
        //Deletes specific id that is in Hotel database
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            return await _context.DeleteHotel(id);
        }

        /// checks if the Hotel id exists in the database
        private async Task<bool> HotelExists(int id)
        {
            Hotel hotel = await _context.GetHotel(id);
            return hotel != null ? true : false;
        }
    }
}
