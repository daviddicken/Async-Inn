using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRooms);
        Task<List<HotelRoom>> GetHotelRooms();
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRooms);
        Task DeleteHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        
    }
}
