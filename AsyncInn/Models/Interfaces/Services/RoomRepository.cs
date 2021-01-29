using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        //-- Injection-----
        private readonly AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        //---------------
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> GetRoom(int Id)
        {
            Room room = await _context.Rooms.FindAsync(Id);

            var roomAmenities = await _context.RoomAmenities
                .Where(x => x.RoomId == Id)
                .Include(x => x.amenity)
                .ToListAsync();

            room.RoomAmenities = roomAmenities;
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var room = await _context.Rooms.Include(ra => ra.RoomAmenities)
                .ThenInclude(ra => ra.amenity)
                .ToListAsync();
            return room;
        }

        public async Task<Room> UpdateRoom(int Id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
       
        public async Task DeleteRoom(int Id)
        {
            Room room = await GetRoom(Id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenities = new RoomAmenities()
            {
                AmenityId = amenityId,
                RoomId = roomId
            };

            _context.Entry(roomAmenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenity(int roomId, int amenityId)
        {
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomId == roomId && x.AmenityId == amenityId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
