using AsyncInn.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTest
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseSqlite(_connection)
                .Options);
            _db.Database.EnsureCreated();
        }
       
        public void Dispose() // destroys temp database after test are finished
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        // Move methods below somewhere else when done so that Mock can be portable

        //Methods used to create test db
        protected async Task<Hotel> CreateTestHotel()
        {
            var hotel = new Hotel
            {
                Name = "test",
                State = "WA",
                StreetAddress = "1234 5th place",
                City = "everett",
                Country = "Snohomish",
                Phone = "5555555"            
            };
            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, hotel.Id);
            return hotel;

        }

        //protected async Task<Room> CreateTestRoom()
        //{
        //    var room = new Room
        //    {
                
        //        Layout = 0,
        //        Name = "test",
        //    };
        //    _db.Add(room);
        //    await _db.SaveChangesAsync();
        //    Assert.NotEqual(0, room.Id);
        //    return room;
        //}

        //protected async Task<HotelRoom> CreateHotelRoom()
        //{
        //    var hotelRoom = new HotelRoom
        //    {
        //        HotelId = 1,
        //        PetFriendly = false,
        //        Rate = 200,
        //        RoomNumber = 99,
        //        RoomId = 1
        //    };
        //    _db.Add(hotelRoom);
        //    await _db.SaveChangesAsync();
            
        //    return hotelRoom;
        //}

        //protected async Task<Amenity> CreateAmenity()
        //{
        //    var amenity = new Amenity
        //    {
        //        Item = "testItem"
        //    };
        //    _db.Add(amenity);
        //    await _db.SaveChangesAsync();
        //    Assert.NotEqual(0, amenity.Id);
        //    return amenity;
        //}
    }
}
