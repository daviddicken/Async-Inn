﻿using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                Layout = 0
              
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 2,
                Name = "Family Fort",
                Layout = 2

            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 3,
                Name = "Solo Suite",
                Layout = 1

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


        }

    }
}