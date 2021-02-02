using AsyncInn.Models.API;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Hotel> Create(HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel()
            {
                Id = hotelDTO.Id,
                Name = hotelDTO.Name,
                StreetAddress = hotelDTO.StreetAddress,
                City = hotelDTO.City,
                State = hotelDTO.State,
                Phone = hotelDTO.Phone
            };
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotel(int id)
        {
            HotelDTO hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            HotelDTO hotel = await _context.Hotels
                                        .Where(h => h.Id == id)
                                        .Select(h => new HotelDTO()
                                        {
                                            Id = h.Id,
                                            Name = h.Name,
                                            StreetAddress = h.StreetAddress,
                                            City = h.City,
                                            State = h.State,
                                            Phone = h.Phone,
                                            Rooms = h.HotelRooms
                                                    .Select(hr => new HotelRoomDTO()
                                                    {
                                                        HotelId = hr.HotelId,
                                                        RoomId = hr.RoomId,
                                                        RoomNumber = hr.RoomNumber,
                                                        Rate = hr.Rate,
                                                        PetFriendly = hr.PetFriendly,
                                                        Room = hr.room.HotelRooms
                                                                .Select(r => new RoomDTO()
                                                                {
                                                                    Id = r.room.Id,
                                                                    Name = r.room.Name,
                                                                    Layout = r.room.Layout,
                                                                    Amenities = r.room.RoomAmenities
                                                                                .Select(ra => new AmenityDTO()
                                                                                {
                                                                                    Id = ra.amenity.Id,
                                                                                    Item = ra.amenity.Item
                                                                                }).ToList()

                                                                }).FirstOrDefault()
                                                    }).ToList()
                                        }).FirstOrDefaultAsync();
            //Hotel hotel = await _context.Hotels.FindAsync(id);

            //var hotelRooms = await _context.HotelRooms
            //    .Where(x => x.HotelId == id)
            //    .Include(x => x.room)
            //    .ToListAsync();

            //hotel.HotelRooms = hotelRooms;
            return hotel;
        }


        public async Task<List<HotelDTO>> GetHotels()
        {
            var hotel = await _context.Hotels
                                        .Select(h => new HotelDTO()
                                        {
                                            Id = h.Id,
                                            Name = h.Name,
                                            StreetAddress = h.StreetAddress,
                                            City = h.City,
                                            State = h.State,
                                            Phone = h.Phone,
                                            Rooms = h.HotelRooms
                                                    .Select(hr => new HotelRoomDTO()
                                                    {
                                                        HotelId = hr.HotelId,
                                                        RoomId = hr.RoomId,
                                                        RoomNumber = hr.RoomNumber,
                                                        Rate = hr.Rate,
                                                        PetFriendly = hr.PetFriendly,
                                                        Room = hr.room.HotelRooms
                                                                .Select(r => new RoomDTO()
                                                                {
                                                                    Id = r.room.Id,
                                                                    Name = r.room.Name,
                                                                    Layout = r.room.Layout
                                                                    //Amenities = r.room.RoomAmenities
                                                                                //.Select(ra => new AmenityDTO()
                                                                                //{
                                                                                //    Id = ra.amenity.Id,
                                                                                //    Item = ra.amenity.Item
                                                                                //}).ToList()

                                                                }).FirstOrDefault()
                                                    }).ToList()
                                        }).ToListAsync();
            return hotel;
        }

        public async Task<Hotel> UpdateHotel(int id, HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel()
            {
                Id = hotelDTO.Id,
                Name = hotelDTO.Name,
                StreetAddress = hotelDTO.StreetAddress,
                City = hotelDTO.City,
                State = hotelDTO.State,
                Phone = hotelDTO.Phone
            };
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
