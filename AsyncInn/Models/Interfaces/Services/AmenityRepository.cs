using AsyncInn.Models.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class AmenityRepository : IAmenity
    {
        private readonly AsyncInnDbContext _context;

        public AmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Amenity> Create(AmenityDTO amenityDTO)
        {
            Amenity amenity = new Amenity()
            {
                Id = amenityDTO.Id,
                Item = amenityDTO.Item
            };

            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;

        }

        public async Task DeleteAmenity(int id)
        {
            AmenityDTO amenity  = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            return await _context.Amenities
                .Select(amenity => new AmenityDTO
                {
                    Id = amenity.Id,
                    Item = amenity.Item
                }).FirstOrDefaultAsync();
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            return await _context.Amenities
                .Select(amenity => new AmenityDTO
                {
                    Id = amenity.Id,
                    Item = amenity.Item
                }).ToListAsync();

        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
