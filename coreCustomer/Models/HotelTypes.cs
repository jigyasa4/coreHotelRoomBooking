﻿using System;
using System.Collections.Generic;

namespace coreCustomer.Models
{
    public partial class HotelTypes
    {
        public HotelTypes()
        {
            Hotels = new HashSet<Hotels>();
        }

        public int HotelTypeId { get; set; }
        public string HotelTypeName { get; set; }
        public string HotelTypeDescription { get; set; }

        public ICollection<Hotels> Hotels { get; set; }
    }
}
