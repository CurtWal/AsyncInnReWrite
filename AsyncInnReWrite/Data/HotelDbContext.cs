using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Design;
using Hotel.Data;
using AsyncInnReWrite.Models;
using AsyncInnReWrite.Models.Interface;
using AsyncInnReWrite.Models.Service;
using System.Net.NetworkInformation;
using AsyncInnReWrite.Models.DTO;

namespace Hotel.Data
{
    public class HotelDbContext : DbContext
    {

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<HotelRooom> HotelRoom { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            HotelRooom Room1 = new HotelRooom { Id = 1, RoomNumber = 105, Rate = 80.0m, PetFriendly = false, HotelID = 1, RoomID = 1 };
            HotelRooom Room2 = new HotelRooom { Id = 2, RoomNumber = 237, Rate = 120.0m, PetFriendly = true, HotelID = 2, RoomID = 2 };
            HotelRooom Room3 = new HotelRooom { Id = 3, RoomNumber = 56, Rate = 40.0m, PetFriendly = true, HotelID = 3, RoomID = 3 };

            Amenity OceanView = new Amenity { Id = 1, Name = "Ocean View" };
            Amenity FreeWiFiInternet = new Amenity { Id = 2, Name = "Free WiFi internet" };
            Amenity MiniBar = new Amenity { Id = 3, Name = "Mini Bar" };

            Hotels TheSunRise = new Hotels { Id = 1, Name = "John Snow", Address = "1705 Baker Street", City = "Memphis", Country = "United States", PhoneNum = "1(901)-555-XxxX", State = "Tennessee" };
            Hotels TheSunSet = new Hotels { Id = 2, Name = "Sara White", Address = "1635 Sam Cooper Drive", City = "Memphis", Country = "United States", PhoneNum = "1(901)-264-XxxX", State = "Tennessee" };
            Hotels TheLateMoon = new Hotels { Id = 3, Name = "Tom Fisher", Address = "1265 Union Ave", City = "Memphis", Country = "United States", PhoneNum = "1(901)-845-XxxX", State = "Tennessee" };

            Room TheKingSuite = new Room { Id = 1, Name = "John Snow", Layout = "The King Suite" };
            Room TheQueenSuite = new Room { Id = 2, Name = "Sara White", Layout = "The Queen Suite" };
            Room TheLoudRoom = new Room { Id = 3, Name = "Tom Fisher", Layout = "The Loud Room" };

            RoomAmenities amenity1 = new RoomAmenities { Id = 1, AmenitiesID = OceanView.Id, RoomID = TheKingSuite.Id };
            RoomAmenities amenity2 = new RoomAmenities { Id = 2, AmenitiesID = FreeWiFiInternet.Id, RoomID = TheQueenSuite.Id };
            RoomAmenities amenity3 = new RoomAmenities { Id = 3, AmenitiesID = MiniBar.Id, RoomID = TheLoudRoom.Id };

            modelBuilder.Entity<Hotels>().HasData(TheSunRise);
            modelBuilder.Entity<Hotels>().HasData(TheSunSet);
            modelBuilder.Entity<Hotels>().HasData(TheLateMoon);

            modelBuilder.Entity<Room>().HasData(TheKingSuite);
            modelBuilder.Entity<Room>().HasData(TheQueenSuite);
            modelBuilder.Entity<Room>().HasData(TheLoudRoom);
            
            modelBuilder.Entity<Amenity>().HasData(OceanView);
            modelBuilder.Entity<Amenity>().HasData(FreeWiFiInternet);
            modelBuilder.Entity<Amenity>().HasData(MiniBar);

            modelBuilder.Entity<RoomAmenities>().HasData(amenity1);
            modelBuilder.Entity<RoomAmenities>().HasData(amenity2);
            modelBuilder.Entity<RoomAmenities>().HasData(amenity3);

            modelBuilder.Entity<HotelRooom>().HasData(Room1);
            modelBuilder.Entity<HotelRooom>().HasData(Room2);
            modelBuilder.Entity<HotelRooom>().HasData(Room3);

        }
        public DbSet<AsyncInnReWrite.Models.DTO.UserDTO> UserDTO { get; set; }
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