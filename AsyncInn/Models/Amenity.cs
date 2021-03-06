﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        [Required]
        public string Item { get; set; }

        public List<RoomAmenities> RoomAmenities { get; set; }
    }
}
