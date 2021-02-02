using AsyncInn.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> Create(AmenityDTO amenity);
        Task<AmenityDTO> GetAmenity(int id);
        Task<List<AmenityDTO>> GetAmenities();
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);
        Task DeleteAmenity(int id);
    }
}
