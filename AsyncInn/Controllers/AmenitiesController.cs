using AsyncInn.Models;
using AsyncInn.Models.API;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
   
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity; 
        }

        // GET: api/Amenity
        [AllowAnonymous]
        [Authorize(Roles = "District Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            return await _amenity.GetAmenities();
        }

        // GET: api/Amenitys/5
        [AllowAnonymous]
        [Authorize(Roles = "District Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            return await _amenity.GetAmenity(id);
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }

            var updateAmenity = await _amenity.UpdateAmenity(id, amenity);
            return Ok(updateAmenity);
        }

        // POST: api/Amenity
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(AmenityDTO amentiy)
        {
            await _amenity.Create(amentiy);

            return CreatedAtAction("GetAmenity", new { id = amentiy.Id }, amentiy);
        }

        // DELETE: api/Amenities/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenity>> DeleteAmenity(int id)
        {
            await _amenity.DeleteAmenity(id);
            return NoContent();
        }
    }
}
