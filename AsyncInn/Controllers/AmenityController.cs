﻿using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
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
        private readonly IAmenity _amenity;

        public AmenityController(IAmenity amenity)
        {
            _amenity = amenity; 
        }

        // GET: api/Amenity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            return Ok (await _amenity.GetAmenities());
        }

        // GET: api/Amenitys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            var amentiy = await _amenity.GetAmenity(id);

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
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amentiy)
        {
            await _amenity.Create(amentiy);

            return CreatedAtAction("GetStudent", new { id = amentiy.Id }, amentiy);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenity>> DeleteAmenity(int id)
        {
            await _amenity.DeleteAmenity(id);
            return NoContent();
        }
    }
}