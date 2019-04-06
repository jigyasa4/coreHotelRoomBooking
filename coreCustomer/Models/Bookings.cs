using System;
using System.Collections.Generic;

namespace coreCustomer.Models
{
    public partial class Bookings
    {
        public Bookings()
        {
            BookingDetails = new HashSet<BookingDetails>();
        }

        public int BookingId { get; set; }
        public double BookingPrice { get; set; }
        public DateTime BookingDate { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Customers Customer { get; set; }
        public ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
