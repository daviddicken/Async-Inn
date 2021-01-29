using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRooms
    {
        public int HotelId { get; set; }
     
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        public  decimal Rate { get; set; }
        public byte PetFriendly { get; set; }

        public Hotel hotel { get; set; }
        public Room room { get; set; }
    }
}
