﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coreHotelRoomBookingAdminPortal.Models;

namespace coreHotelRoomBookingAdminPortal.Migrations
{
    [DbContext(typeof(HotelRoomDbContext))]
    [Migration("20190308094230_CreateBook")]
    partial class CreateBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<double>("BookingPrice");

                    b.Property<int>("CustomerId");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<long>("ContactNumber");

                    b.Property<string>("Country");

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("State");

                    b.Property<int>("Zip");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelAddress")
                        .IsRequired();

                    b.Property<string>("HotelCity");

                    b.Property<long>("HotelContactNumber");

                    b.Property<string>("HotelCountry")
                        .IsRequired();

                    b.Property<string>("HotelDescription")
                        .IsRequired();

                    b.Property<string>("HotelDistrict");

                    b.Property<string>("HotelEmailId")
                        .IsRequired();

                    b.Property<string>("HotelImage");

                    b.Property<string>("HotelName")
                        .IsRequired();

                    b.Property<string>("HotelRating");

                    b.Property<string>("HotelState");

                    b.Property<int>("HotelTypeId");

                    b.HasKey("HotelId");

                    b.HasIndex("HotelTypeId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId");

                    b.Property<string>("RoomDescription")
                        .IsRequired();

                    b.Property<string>("RoomImage")
                        .IsRequired();

                    b.Property<int>("RoomPrice");

                    b.Property<string>("RoomType")
                        .IsRequired();

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.HotelType", b =>
                {
                    b.Property<int>("HotelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelTypeDescription")
                        .IsRequired();

                    b.Property<string>("HotelTypeName")
                        .IsRequired();

                    b.HasKey("HotelTypeId");

                    b.ToTable("HotelTypes");
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.RoomFacility", b =>
                {
                    b.Property<int>("RoomFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AirConditioner");

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("Refrigerator");

                    b.Property<string>("RoomFacilityDescription")
                        .IsRequired();

                    b.Property<int>("RoomId");

                    b.Property<bool>("Wifi");

                    b.HasKey("RoomFacilityId");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("RoomFacilities");
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.Booking", b =>
                {
                    b.HasOne("coreHotelRoomBookingAdminPortal.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.Hotel", b =>
                {
                    b.HasOne("coreHotelRoomBookingAdminPortal.Models.HotelType", "HotelType")
                        .WithMany("Hotels")
                        .HasForeignKey("HotelTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.HotelRoom", b =>
                {
                    b.HasOne("coreHotelRoomBookingAdminPortal.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreHotelRoomBookingAdminPortal.Models.RoomFacility", b =>
                {
                    b.HasOne("coreHotelRoomBookingAdminPortal.Models.HotelRoom", "HotelRoom")
                        .WithOne("RoomFacility")
                        .HasForeignKey("coreHotelRoomBookingAdminPortal.Models.RoomFacility", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
