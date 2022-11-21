﻿// <auto-generated />
using System;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsyncInnReWrite.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20221121045055_UpdatedNewHotel")]
    partial class UpdatedNewHotel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AsyncInnReWrite.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ocean View"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Free WiFi internet"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mini Bar"
                        });
                });

            modelBuilder.Entity("AsyncInnReWrite.Models.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRoom");
                });

            modelBuilder.Entity("AsyncInnReWrite.Models.Hotels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1705 Baker Street",
                            City = "Memphis",
                            Country = "United States",
                            Name = "John Snow",
                            PhoneNum = "1(901)-555-XxxX",
                            State = "Tennessee"
                        },
                        new
                        {
                            Id = 2,
                            Address = "1635 Sam Cooper Drive",
                            City = "Memphis",
                            Country = "United States",
                            Name = "Sara White",
                            PhoneNum = "1(901)-264-XxxX",
                            State = "Tennessee"
                        },
                        new
                        {
                            Id = 3,
                            Address = "1265 Union Ave",
                            City = "Memphis",
                            Country = "United States",
                            Name = "Tom Fisher",
                            PhoneNum = "1(901)-845-XxxX",
                            State = "Tennessee"
                        });
                });

            modelBuilder.Entity("AsyncInnReWrite.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Layout")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Layout = "The King Suite",
                            Name = "John Snow"
                        },
                        new
                        {
                            Id = 2,
                            Layout = "The Queen Suite",
                            Name = "Sara White"
                        },
                        new
                        {
                            Id = 3,
                            Layout = "The Loud Room",
                            Name = "Tom Fisher"
                        });
                });

            modelBuilder.Entity("AsyncInnReWrite.Models.Amenity", b =>
                {
                    b.HasOne("AsyncInnReWrite.Models.Room", null)
                        .WithMany("Amenities")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("AsyncInnReWrite.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInnReWrite.Models.Hotels", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInnReWrite.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("AsyncInnReWrite.Models.Hotels", b =>
                {
                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("AsyncInnReWrite.Models.Room", b =>
                {
                    b.Navigation("Amenities");
                });
#pragma warning restore 612, 618
        }
    }
}
