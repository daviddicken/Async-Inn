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
        private readonly AsyncInnDbContext _context;

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
            HotelRoom hotelRoom = await _context.HotelRooms
                                    .Where(hr => (hr.HotelId == hotelId && hr.RoomNumber == roomNumber))
                                    .Include(hr => hr.Hotel)
                                    .Include(hr => hr.Room)
                                    .ThenInclude(r => r.RoomAmenities)
                                    .ThenInclude(ra => ra.amenity).FirstOrDefaultAsync();

            HotelRoomDTO hotelRoomDTO = new HotelRoomDTO()
            {
                HotelId = hotelRoom.HotelId,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                RoomId = hotelRoom.RoomId,
                Room = new RoomDTO()
                {
                    Id = hotelRoom.Room.Id,
                    Name = hotelRoom.Room.Name,
                    Layout = hotelRoom.Room.Layout,
                    Amenities = hotelRoom.Room.RoomAmenities
                                .Select(ra => new AmenityDTO()
                                {
                                    Id = ra.amenity.Id,
                                    Item = ra.amenity.Item
                                }).ToList()
                }

            };
            //return await _context.HotelRooms
            //    .Select(hotelRoom => new HotelRoomDTO
            //    {
            //        HotelId = hotelRoom.HotelId,
            //        RoomNumber = hotelRoom.RoomNumber,
            //        RoomId = hotelRoom.RoomId,
            //        PetFriendly = hotelRoom.PetFriendly,
            //        Rate = hotelRoom.Rate,
            //        Room = new RoomDTO()
            //        {
            //            Id = hotelRoom.Room.Id,
            //            Name = hotelRoom.Room.Name,
            //            Layout = hotelRoom.Room.Layout,
            //            Amenities = hotelRoom.Room.RoomAmenities
            //                                        .Select(ra => new AmenityDTO()
            //                                        {
            //                                            Id = ra.amenity.Id,
            //                                            Item = ra.amenity.Item
            //                                        }).ToList()
            //        }

            //    }).FirstOrDefaultAsync();

            //HotelRoom hotelRoom = await _context.HotelRooms
            //    .Where(x => (x.HotelId == hotelId && x.RoomNumber == roomNumber))
            //    .Include(x => x.hotel)
            //    .Include(x => x.room)
            //    .FirstOrDefaultAsync();

            return hotelRoomDTO;
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
            var hotelRoom = await _context.HotelRooms
                            .Select(hr => new HotelRoomDTO()
                            {
                                HotelId = hr.HotelId,
                                RoomNumber = hr.RoomNumber,
                                Rate = hr.Rate,
                                PetFriendly = hr.PetFriendly,
                                RoomId = hr.RoomId,
                                Room = new RoomDTO()
                                {
                                    Id = hr.Room.Id,
                                    Name = hr.Room.Name,
                                    Layout = hr.Room.Layout,
                                    Amenities = hr.Room.RoomAmenities
                                                .Select(ra => new AmenityDTO()
                                                {
                                                    Id = ra.amenity.Id,
                                                    Item = ra.amenity.Item
                                                }).ToList()
                                }
                            }).ToListAsync();
            return hotelRoom;

            //return await _context.HotelRooms
            //    .Select(hotelRoom => new HotelRoomDTO
            //    {
            //        HotelId = hotelRoom.HotelId,
            //        RoomNumber = hotelRoom.RoomNumber,
            //        RoomId = hotelRoom.RoomId,
            //        PetFriendly = hotelRoom.PetFriendly,
            //        Rate = hotelRoom.Rate,
            //        Room = new RoomDTO()
            //        {
            //            Id = hotelRoom.Room.Id,
            //            Name = hotelRoom.Room.Name,
            //            Layout = hotelRoom.Room.Layout,
            //            Amenities = hotelRoom.Room.RoomAmenities
            //                                        .Select(ra => new AmenityDTO()
            //                                        {
            //                                            Id = ra.amenity.Id,
            //                                            Item = ra.amenity.Item
            //                                        }).ToList()
            //        }
            //    }).ToListAsync();

            //var hotelRoom = await _context.HotelRooms
            //    .Include(x => x.hotel)
            //    .Include(x => x.room)
            //    .ThenInclude(x => x.RoomAmenities)
            //    .ThenInclude(x => x.amenity)
            //    .ToListAsync();
            //return hotelRoom;
        }

        //public async Task<HotelRoom> UpdateHotelRoom( HotelRoomDTO hotelRoomDTO)
        public async Task<HotelRoom> UpdateHotelRoom(HotelRoomDTO hotelRoomDTO) //TOD: add hotelId and roomNumber and wire up a check before updating object

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
           
            HotelRoom hotelRoom = await _context.HotelRooms
                                .Where(hr => hr.HotelId == hotelId && hr.RoomNumber == roomNumber)
                                .FirstOrDefaultAsync();
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

