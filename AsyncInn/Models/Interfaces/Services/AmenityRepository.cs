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
            Amenity amenity = await _context.Amenities.FindAsync(id);
            //Amenity amenity  = await _context.Amenities
            //                        .Where(a => a.Id == id)
            //                        .FirstOrDefaultAsync();


            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            AmenityDTO amenityDTO = await _context.Amenities
                                        .Where(a => a.Id == id)
                                        .Select(dbobj => new AmenityDTO
                                        {
                                            Id = dbobj.Id,
                                            Item = dbobj.Item
                                        })
                                        .FirstOrDefaultAsync();
            return amenityDTO;
            //return await _context.Amenities
            //    .Select(amenity => new AmenityDTO
            //    {
            //        Id = amenity.Id,
            //        Item = amenity.Item
            //    }).FirstOrDefaultAsync();
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var amenities = await _context.Amenities
                            .Select(amenities => new AmenityDTO
                            {
                                Id = amenities.Id,
                                Item = amenities.Item
                            })
                            .ToListAsync();
            return amenities;

            //return await _context.Amenities
            //    .Select(amenity => new AmenityDTO
            //    {
            //        Id = amenity.Id,
            //        Item = amenity.Item
            //    }).ToListAsync();

        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            Amenity amenity1 = new Amenity()
            {
                Item = amenity.Item,
                Id = amenity.Id
            };

            _context.Entry(amenity1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity1;
        }
    }
}
