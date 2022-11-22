using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Design;
using Hotel.Data;
using AsyncInnReWrite.Models;
using AsyncInnReWrite.Models.Interface;
using AsyncInnReWrite.Models.Service;

namespace Hotel.Data
{
    public class HotelDbContext : DbContext
    {

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Amenity OceanView = new Amenity { Id = 1, Name = "Ocean View" };
            Amenity FreeWiFiInternet = new Amenity { Id = 2, Name = "Free WiFi internet" };
            Amenity MiniBar = new Amenity { Id = 3, Name = "Mini Bar" };

            modelBuilder.Entity<Hotels>().HasData(new Hotels { Id = 1, Name = "John Snow", Address = "1705 Baker Street", City = "Memphis", Country = "United States", PhoneNum = "1(901)-555-XxxX", State = "Tennessee" });
            modelBuilder.Entity<Hotels>().HasData(new Hotels { Id = 2, Name = "Sara White", Address = "1635 Sam Cooper Drive", City = "Memphis", Country = "United States", PhoneNum = "1(901)-264-XxxX", State = "Tennessee" });
            modelBuilder.Entity<Hotels>().HasData(new Hotels { Id = 3, Name = "Tom Fisher", Address = "1265 Union Ave", City = "Memphis", Country = "United States", PhoneNum = "1(901)-845-XxxX", State = "Tennessee" });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 1, Name = "John Snow", Layout = "The King Suite" });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 2, Name = "Sara White", Layout = "The Queen Suite" });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 3, Name = "Tom Fisher", Layout = "The Loud Room" });
            
            modelBuilder.Entity<Amenity>().HasData(OceanView);
            modelBuilder.Entity<Amenity>().HasData(FreeWiFiInternet);
            modelBuilder.Entity<Amenity>().HasData(MiniBar);

            modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities { Id = 1, AmenitiesID = 1, RoomID = 1 });
            modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities { Id = 2, AmenitiesID = 2, RoomID = 2 });
            modelBuilder.Entity<RoomAmenities>().HasData(new RoomAmenities { Id = 3, AmenitiesID = 3, RoomID = 3 });
        }
    }
}

public class YourDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{
    public HotelDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
        var connectionString = configuration.GetConnectionString("AzureContext");
        var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new HotelDbContext(optionsBuilder.Options);
    }
}