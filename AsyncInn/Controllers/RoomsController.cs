using AsyncInn.Models.API;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [AllowAnonymous]
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "Property Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return await _room.GetRooms();
        }

        // GET: api/Rooms/5
        [AllowAnonymous]
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "Property Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            return await _room.GetRoom(id);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "Property Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var updateRoom = await _room.UpdateRoom(id, room);
            return Ok(updateRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "Property Manager")]
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomDTO>> DeleteRoom(int id)
        {
            await _room.DeleteRoom(id);
            return NoContent();
        }

        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "Agent")]
        [HttpPost]
        [Route("{roomId}/{amenityId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }

        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "Agent")]
        [HttpDelete]
        [Route("{roomId}/{amenityId}")]
        public async Task<IActionResult> RemoveAmenity(int roomId, int amenityId)
        {
            await _room.RemoveAmenity(roomId, amenityId);
            return NoContent();
        }

    }
}
