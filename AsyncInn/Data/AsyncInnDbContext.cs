using AsyncInn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<RoomAmenities>().HasKey(
                roomAmenities => new { roomAmenities.RoomId, roomAmenities.AmenityId });

            modelBuilder.Entity<HotelRoom>().HasKey(
               hotelRooms => new {hotelRooms.HotelId, hotelRooms.RoomNumber });

            SeedRole(modelBuilder, "District Manager", "create", "read", "update", "delete");
            SeedRole(modelBuilder, "Property Manager");
            SeedRole(modelBuilder, "Agent");


            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                Id = 1,
                Name = "WestInn",
                City = "Seattle",
                Country = "USA",
                Phone = "(206)-555-1212",
                State = "WA",
                StreetAddress = "123 4th ave"
            });

            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                Id = 2,
                Name = "DaysInn",
                City = "Everett",
                Country = "USA",
                Phone = "(425)-773-1212",
                State = "WA",
                StreetAddress = "456 hwy 99"
            });

            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                Id = 3,
                Name = "DoggyInn",
                City = "San Diego",
                Country = "USA",
                Phone = "(619)-555-1212",
                State = "CA",
                StreetAddress = "418 Palmera Dr"
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 1,
                Name = "Pups Place",
                Layout = Room.Layouts.TwoBedroom
              
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 2,
                Name = "Family Fort",
                Layout = Room.Layouts.OneBedroom

            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 3,
                Name = "Solo Suite",
                Layout = Room.Layouts.Studio

            });

            modelBuilder.Entity<Amenity>().HasData(new Amenity
            {
                Id = 1,
                Item = "Microwave"

            });

            modelBuilder.Entity<Amenity>().HasData(new Amenity
            {
                Id = 2,
                Item = "Fridge"

            });

            modelBuilder.Entity<Amenity>().HasData(new Amenity
            {
                Id = 3,
                Item = "OceanView"

            });


            modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities
            {
                AmenityId = 2,
                RoomId = 2

            });

            modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities
            {
                AmenityId = 3,
                RoomId = 1

            });

            modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities
            {
                AmenityId = 3,
                RoomId = 2

            });

            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            {
                HotelId = 1,
                RoomId = 1,
                RoomNumber = 1,
                Rate = 150,
                PetFriendly = true
            });

            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            {
                HotelId = 1,
                RoomId = 3,
                RoomNumber = 2,
                Rate = 50,
                PetFriendly = true
            });

            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            {
                HotelId = 3,
                RoomId = 3,
                RoomNumber = 3,
                Rate = 20,
                PetFriendly = false
            });
        }

        private int Id = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);

            var roleClaims = permissions.Select(permission =>          
                new IdentityRoleClaim<string>
                {
                    Id = Id++,
                    RoleId = role.Id,
                    ClaimType = "permissions",
                    ClaimValue = permission
                }
            );
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }

    }
}
