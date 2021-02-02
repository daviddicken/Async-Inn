using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AsyncInn.Models.Room;

namespace AsyncInn.Models.API
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Layouts Layout { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
    }
}
