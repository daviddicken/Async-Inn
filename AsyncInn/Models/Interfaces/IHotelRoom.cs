using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;
using AsyncInn.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomS> Create(HotelRoomDTO hotelRooms);
        Task<List<HotelRoomDTO>> GetHotelRooms();
        Task<HotelRoomDTO> UpdateHotelRoom(HotelRoomDTO hotelRooms);
        Task DeleteHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);
        
    }
}
