using AsyncInn.Models.API;
using AsyncInn.Models.Interfaces.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTest
{
    public class UnitTest1 : Mock
    {
        [Fact]
        public async Task CreateHotel()
        {
            // Arrange
            var hotel = await CreateTestHotel();
            //var room = await CreateTestRoom();

            //HotelDTO hotelDTO = new HotelDTO()
            //{
            //    City = "testCity",
            //    Name = "testHotel",
            //    State = "wa",
            //    StreetAddress = "4536",
            //    Phone = "6555"
            //};

            //var repository = new HotelRepository(_db);

           // var actualHotel = await repository.GetHotel(hotel.Id);
            // Act
            Assert.Equal("test", hotel.Name);
        }
        //[Fact]
        //public async Task DeleteHotelTest()
        //{
        //    var hotel = await CreateTestHotel();
        //    var repository = new HotelRepository(_db);
        //}
    }
}
