using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }
     
        public int RoomId { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        public  decimal Rate { get; set; }
        [Required]
        public bool PetFriendly { get; set; }

        public Hotel hotel { get; set; }
        public Room room { get; set; }

    }
}
