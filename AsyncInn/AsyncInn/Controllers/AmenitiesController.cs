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
    [Route("api/amenities")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        /// This is IAmenitiesManager object that is created when the this route is called
        private readonly IAmenitiesManager _context;

        /// assigning the IAmenitiesManager context to private context property
        public AmenitiesController(IAmenitiesManager context)
        {
            _context = context;
        }

        // GET: api/Amenities
        /// Get route that is shows list of amenities in the method
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenitiesDTO>>> GetAmenities() => await _context.GetAmenities();

        // GET: api/Amenities/5
        /// Get route that shows specific amenity when user picks
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenitiesDTO>> GetAmenities(int id)
        {
            var amenities = await _context.GetAmenity(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        // PUT: api/Amenities/5
        // Update method that checks for the ID and change if it does exist otherwise return bad request
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return BadRequest();
            }

            try
            {
                await _context.UpdateAmenity(amenities);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await AmenitiesExists(id))
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

        // POST: api/Amenities
        // Creates new amenity when user input information
        [HttpPost]
        public async Task<ActionResult<AmenitiesDTO>> PostAmenities(Amenities amenities)
        {
            var newAmmenity = await _context.CreateAmenity(amenities);

            return CreatedAtAction("GetAmenities", new { id = newAmmenity.ID }, newAmmenity);
        }

        // DELETE: api/Amenities/5
        //Deletes specific id that is in amenity database
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            return await _context.DeleteAmenity(id);
        }

        /// checks if the amenity id exists in the database
        private async Task<bool> AmenitiesExists(int id)
        {
            AmenitiesDTO amenities = await _context.GetAmenity(id);

            return amenities != null ? true : false;
        }
    }
}
