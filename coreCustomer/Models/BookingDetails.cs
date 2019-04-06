using System;
using System.Collections.Generic;

namespace coreCustomer.Models
{
    public partial class BookingDetails
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int Qunatity { get; set; }

        public Bookings Booking { get; set; }
        public HotelRooms Room { get; set; }
    }
}
