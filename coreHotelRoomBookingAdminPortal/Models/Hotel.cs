using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class Hotel
    {[Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int HotelId { get; set; }
        [Required]
       public string HotelName { get; set; }
        [Required]
     public  string HotelAddress { get; set; }
        [Required]

      public long HotelContactNumber { get; set; }
        [Required]

       public string HotelCountry { get; set; }

      public  string HotelCity { get; set; }

        public string HotelState { get; set; }

        public string HotelDistrict { get; set; }
        [Required]
       public string HotelEmailId { get; set; }

     public   string HotelRating { get; set; }
      public string HotelImage { get; set; }
        [Required]
       public string HotelDescription { get; set; }
     
        public List<HotelRoom> HotelRooms { get; set; }
        public int HotelTypeId { get; set; }
        public HotelType HotelType{ get; set; }
    }
}
