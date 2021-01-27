using AsyncInn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly AsyncInnDbContext _context;

        public AmenityController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: api/Amenity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenitys()
        {
            return await _context.Amenities.ToListAsync();
        }

        // GET: api/Amenitys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            var amentiy = await _context.Amenities.FindAsync(id);

            if (amentiy == null)
            {
                return NotFound();
            }

            return amentiy;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amentiy)
        {
            if (id != amentiy.Id)
            {
                return BadRequest();
            }

            _context.Entry(amentiy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(id))
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

        // POST: api/Amenity
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amentiy)
        {
            _context.Amenities.Add(amentiy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = amentiy.Id }, amentiy);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenity>> DeleteAmenity(int id)
        {
            var amentiy = await _context.Amenities.FindAsync(id);
            if (amentiy == null)
            {
                return NotFound();
            }

            _context.Amenities.Remove(amentiy);
            await _context.SaveChangesAsync();

            return amentiy;
        }

        private bool AmenityExists(int id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }
    }
}
