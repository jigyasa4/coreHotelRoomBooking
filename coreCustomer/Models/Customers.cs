using System;
using System.Collections.Generic;

namespace coreCustomer.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long ContactNumber { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public ICollection<Bookings> Bookings { get; set; }
    }
}
