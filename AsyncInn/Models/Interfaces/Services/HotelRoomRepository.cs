using AsyncInn.Models.API;
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

     
        public async Task<HotelRoom> Create(HotelRoomDTO HotelRoomDTO)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelId = HotelRoomDTO.HotelId,
                RoomId = HotelRoomDTO.RoomId,
                Rate = HotelRoomDTO.Rate,
                RoomNumber = HotelRoomDTO.RoomNumber,
                PetFriendly = HotelRoomDTO.PetFriendly
            };

            _context.Entry(hotelRoom).State = EntityState.Added;  
            await _context.SaveChangesAsync();
            return hotelRoom;

        }

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
        {

            return await _context.HotelRooms
                .Select(hotelRoom => new HotelRoomDTO
                {
                    HotelId = hotelRoom.HotelId,
                    RoomNumber = hotelRoom.RoomNumber,
                    RoomId = hotelRoom.RoomId,
                    PetFriendly = hotelRoom.PetFriendly,
                    Rate = hotelRoom.Rate,
                    Room = new RoomDTO()
                    {
                        Id = hotelRoom.room.Id,
                        Name = hotelRoom.room.Name,
                        Layout = hotelRoom.room.Layout,
                        Amenities = hotelRoom.room.RoomAmenities
                                                    .Select(ra => new AmenityDTO()
                                                    {
                                                        Id = ra.amenity.Id,
                                                        Item = ra.amenity.Item
                                                    }).ToList()
                    }

                }).FirstOrDefaultAsync();
            //HotelRoom hotelRoom = await _context.HotelRooms
            //    .Where(x => (x.HotelId == hotelId && x.RoomNumber == roomNumber))
            //    .Include(x => x.hotel)
            //    .Include(x => x.room)
            //    .FirstOrDefaultAsync();

            //return hotelRoom;
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
            return await _context.HotelRooms
                .Select(hotelRoom => new HotelRoomDTO
                {
                    HotelId = hotelRoom.HotelId,
                    RoomNumber = hotelRoom.RoomNumber,
                    RoomId = hotelRoom.RoomId,
                    PetFriendly = hotelRoom.PetFriendly,
                    Rate = hotelRoom.Rate,
                    Room = new RoomDTO()
                    {
                        Id = hotelRoom.room.Id,
                        Name = hotelRoom.room.Name,
                        Layout = hotelRoom.room.Layout,
                        Amenities = hotelRoom.room.RoomAmenities
                                                    .Select(ra => new AmenityDTO()
                                                    {
                                                        Id = ra.amenity.Id,
                                                        Item = ra.amenity.Item
                                                    }).ToList()
                    }
                }).ToListAsync();
            //var hotelRoom = await _context.HotelRooms
            //    .Include(x => x.hotel)
            //    .Include(x => x.room)
            //    .ThenInclude(x => x.RoomAmenities)
            //    .ThenInclude(x => x.amenity)
            //    .ToListAsync();
            //return hotelRoom;
        }

        public async Task<HotelRoom> UpdateHotelRoom( HotelRoomDTO hotelRoomDTO)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelId = hotelRoomDTO.HotelId,
                RoomId = hotelRoomDTO.RoomId,
                Rate = hotelRoomDTO.Rate,
                RoomNumber = hotelRoomDTO.RoomNumber,
                PetFriendly = hotelRoomDTO.PetFriendly
            };
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task DeleteHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

