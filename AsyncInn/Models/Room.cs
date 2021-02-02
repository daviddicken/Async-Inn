using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Layouts Layout { get; set; }

        public List<RoomAmenities> RoomAmenities { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }
        public enum Layouts
        {
            Studio = 0,
            OneBedroom,
            TwoBedroom
        }
    }
}
