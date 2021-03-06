﻿using AsyncInn.Models.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces //.Services
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
        public async Task<Room> Create(RoomDTO roomDTO)
        {
            Room room = new Room()
            {
                Id = roomDTO.Id,
                Layout = roomDTO.Layout,
                Name = roomDTO.Name              
            };

            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<RoomDTO> GetRoom(int Id)
        {
            //return await _context.Rooms
            RoomDTO room = await _context.Rooms
                .Where(r => r.Id == Id)
                .Select(room => new RoomDTO
                {
                    Id = room.Id,
                    Layout = room.Layout,
                    Name = room.Name,
                    Amenities = room.RoomAmenities
                                    .Select(ra => new AmenityDTO
                                    {
                                        Id = ra.amenity.Id,
                                        Item = ra.amenity.Item
                                    }).ToList()
                }).FirstOrDefaultAsync();

            return room;
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            var room = await _context.Rooms
                 .Select(room => new RoomDTO
                 {
                     Id = room.Id,
                     Layout = room.Layout,
                     Name = room.Name,
                     Amenities = room.RoomAmenities
                                     .Select(ra => new AmenityDTO
                                     {
                                         Id = ra.amenity.Id,
                                         Item = ra.amenity.Item
                                     }).ToList()
                 }).ToListAsync();

            return room;

            //var rooms = await _context.Rooms
            //    .Include(ra => ra.RoomAmenities)
            //    .ThenInclude(ra => ra.amenity)
            //    .Include(hr => hr.HotelRooms)
            //    .ThenInclude(h => h.hotel)
            //    .ToListAsync();

            //return rooms;
        }

        public async Task<Room> UpdateRoom(int Id, RoomDTO roomDTO)
        {
            Room room = new Room()
            {
                Id = roomDTO.Id,
                Layout = roomDTO.Layout,
                Name = roomDTO.Name
            };
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
       
        public async Task DeleteRoom(int Id)
        {
            Room room = await _context.Rooms.FindAsync(Id);
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
