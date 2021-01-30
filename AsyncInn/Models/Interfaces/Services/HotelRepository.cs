﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class HotelRepository : IHotel
    {
        private readonly AsyncInnDbContext _context;
        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);

            var hotelRooms = await _context.HotelRooms
                .Where(x => x.HotelId == id)
                .Include(x => x.room)
                .ToListAsync();

            hotel.HotelRooms = hotelRooms;
            return hotel;
        }


        public async Task<List<Hotel>> GetHotels()
        {
            var hotel = await _context.Hotels.Include(ra => ra.HotelRooms)
               .ThenInclude(ra => ra.room)
               .ToListAsync();
            return hotel;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
