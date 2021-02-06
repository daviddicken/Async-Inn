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
            //HotelDTO hotel = await GetHotel(id);
            Hotel hotel = await _context.Hotels.FindAsync(id);

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
                                                        Room = hr.Room.HotelRooms
                                                                .Select(r => new RoomDTO()
                                                                {
                                                                    Id = r.Room.Id,
                                                                    Name = r.Room.Name,
                                                                    Layout = r.Room.Layout
                                                                    //Amenities = r.room.RoomAmenities
                                                                    //            .Select(ra => new AmenityDTO()
                                                                    //            {
                                                                    //                Id = ra.amenity.Id,
                                                                    //                Item = ra.amenity.Item
                                                                    //            }).ToList()

                                                                }).FirstOrDefault()
                                                    }).ToList()
                                        }).FirstOrDefaultAsync();
            //Hotel hotel = await _context.Hotels.FindAsync(id);

            //var hotelRooms = await _context.HotelRooms
            //    .Where(x => x.HotelId == id)
            //    .Include(x => x.room)
            //    .ToListAsync();

            //hotel.HotelRooms = hotelRooms;
            //foreach(var hotelRoom in hotel.Rooms)
            //{
            //    var ra = await _context.RoomAmenities;
            //              .Where(ra => ra.RoomId == hotelRoom.RoomId)
            //              .Select(a => new AmenityDTO()
            //              {
            //                  Id = a.amenity.Id,
            //                  Item = a.amenity.Item
            //              })
            //              .ToListAsync();
            //    hotelRoom.Room.Amenities = ra; 
            //}
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
                                                        Room = hr.Room.HotelRooms
                                                                .Select(r => new RoomDTO()
                                                                {
                                                                    Id = r.Room.Id,
                                                                    Name = r.Room.Name,
                                                                    Layout = r.Room.Layout
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
