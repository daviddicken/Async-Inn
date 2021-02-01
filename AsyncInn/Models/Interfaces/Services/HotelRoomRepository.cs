using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> Create(HotelRoom HotelRoom)
        {
            _context.Entry(HotelRoom).State = EntityState.Added;
            
            await _context.SaveChangesAsync();
            return HotelRoom;

        }

        public async Task DeleteHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            var hotelRoom = await _context.HotelRooms
                .Include(x => x.hotel)
                .Include(x => x.room)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(x => x.amenity)
                .ToListAsync();
            return hotelRoom;
        }

        public async Task<HotelRoom> UpdateHotelRoom( HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRooms
                .Where(x => (x.HotelId == hotelId && x.RoomNumber == roomNumber))
                .Include(x => x.hotel)
                .Include(x => x.room)
                .FirstOrDefaultAsync();

            return hotelRoom;
        }
    }
}

