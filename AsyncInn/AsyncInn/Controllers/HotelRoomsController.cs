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
    public class HotelRoomsController : ControllerBase
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRooms>>> GetHotelRoom()
        {
            return await _context.HotelRoom.ToListAsync();
        }

        // GET: api/HotelRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRooms>> GetHotelRooms(int id)
        {
            var hotelRooms = await _context.HotelRoom.FindAsync(id);

            if (hotelRooms == null)
            {
                return NotFound();
            }

            return hotelRooms;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRooms(int id, HotelRooms hotelRooms)
        {
            if (id != hotelRooms.HotelID)
            {
                return BadRequest();
            }

            _context.Entry(hotelRooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomsExists(id))
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

        // POST: api/HotelRooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HotelRooms>> PostHotelRooms(HotelRooms hotelRooms)
        {
            _context.HotelRoom.Add(hotelRooms);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelRoomsExists(hotelRooms.HotelID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHotelRooms", new { id = hotelRooms.HotelID }, hotelRooms);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRooms>> DeleteHotelRooms(int id)
        {
            var hotelRooms = await _context.HotelRoom.FindAsync(id);
            if (hotelRooms == null)
            {
                return NotFound();
            }

            _context.HotelRoom.Remove(hotelRooms);
            await _context.SaveChangesAsync();

            return hotelRooms;
        }

        private bool HotelRoomsExists(int id)
        {
            return _context.HotelRoom.Any(e => e.HotelID == id);
        }
    }
}
