using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.API;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
            {
              _hotelRoom = hotelRoom;
            }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms()
        {
            return Ok(await _hotelRoom.GetHotelRooms());
        }

        // GET: api/HotelRooms/5
        [HttpGet("{hotelId}/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelId, int roomNumber)
        {


            return await _hotelRoom.GetHotelRoom(hotelId, roomNumber);
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{hotelId}/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(HotelRoomDTO hotelRoom)
        {
            var updateRoom = await _hotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(updateRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom)
        {
            await _hotelRoom.Create(hotelRoom);

            return CreatedAtAction("GetHotelRoom", new { hotelId = hotelRoom.HotelId, roomNumber = hotelRoom.RoomNumber  }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int id, int roomNumber)
        {
            await _hotelRoom.DeleteHotelRoom(id, roomNumber);
            return NoContent();
        }
    }
}
