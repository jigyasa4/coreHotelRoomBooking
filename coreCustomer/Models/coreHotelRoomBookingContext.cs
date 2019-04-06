using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coreCustomer.Models
{
    public partial class coreHotelRoomBookingContext : DbContext
    {
        public coreHotelRoomBookingContext()
        {
        }

        public coreHotelRoomBookingContext(DbContextOptions<coreHotelRoomBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetails> BookingDetails { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<HotelRooms> HotelRooms { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<HotelTypes> HotelTypes { get; set; }
        public virtual DbSet<RoomFacilities> RoomFacilities { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRD-519; Database=coreHotelRoomBooking; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetails>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.RoomId });

                entity.HasIndex(e => e.RoomId);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.RoomId);
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.CheckIn).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.CheckOut).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
            });

            modelBuilder.Entity<HotelRooms>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.HasIndex(e => e.HotelId);

                entity.Property(e => e.RoomDescription).IsRequired();

                entity.Property(e => e.RoomImage).IsRequired();

                entity.Property(e => e.RoomType).IsRequired();

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelRooms)
                    .HasForeignKey(d => d.HotelId);
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.HasKey(e => e.HotelId);

                entity.HasIndex(e => e.HotelTypeId);

                entity.Property(e => e.HotelAddress).IsRequired();

                entity.Property(e => e.HotelCountry).IsRequired();

                entity.Property(e => e.HotelDescription).IsRequired();

                entity.Property(e => e.HotelEmailId).IsRequired();

                entity.Property(e => e.HotelName).IsRequired();

                entity.HasOne(d => d.HotelType)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.HotelTypeId);
            });

            modelBuilder.Entity<HotelTypes>(entity =>
            {
                entity.HasKey(e => e.HotelTypeId);

                entity.Property(e => e.HotelTypeDescription).IsRequired();

                entity.Property(e => e.HotelTypeName).IsRequired();
            });

            modelBuilder.Entity<RoomFacilities>(entity =>
            {
                entity.HasKey(e => e.RoomFacilityId);

                entity.HasIndex(e => e.RoomId)
                    .IsUnique();

                entity.Property(e => e.RoomFacilityDescription).IsRequired();

                entity.HasOne(d => d.Room)
                    .WithOne(p => p.RoomFacilities)
                    .HasForeignKey<RoomFacilities>(d => d.RoomId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Uname)
                    .HasColumnName("uname")
                    .IsUnicode(false);
            });
        }
    }
}
