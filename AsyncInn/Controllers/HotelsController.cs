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
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
           _hotel = hotel;
        }

        // GET: api/Hotel
        [AllowAnonymous]
        [Authorize(Roles = "District Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            return Ok(await _hotel.GetHotels());
        }


        // GET: api/Hotels/5
        [AllowAnonymous]
        [Authorize(Roles = "District Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _hotel.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDTO hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            var updateHotel = await _hotel.UpdateHotel(id, hotel);
            return Ok(updateHotel);        
        }

        // POST: api/Hotel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(HotelDTO hotel)
        {
            await _hotel.Create(hotel);
            return CreatedAtAction("GetStudent", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelDTO>> DeleteHotel(int id)
        {
            await _hotel.DeleteHotel(id);
            return NoContent();
        }
    }
}
