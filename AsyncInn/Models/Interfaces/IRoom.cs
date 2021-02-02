using AsyncInn.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(RoomDTO room);
        Task<RoomDTO> GetRoom(int Id);
        Task<List<RoomDTO>> GetRooms();
        Task<Room> UpdateRoom(int Id, RoomDTO room);
        Task DeleteRoom(int Id);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmenity(int roomId, int amenityId);

    }
}
