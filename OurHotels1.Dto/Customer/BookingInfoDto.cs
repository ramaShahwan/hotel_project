using OurHotels.Dto.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Customer
{
   public class BookingInfoDto
    {
        public string HotelName { get; set; }
        public City City { get; set; } // Add the City property
        public byte[] HotelImage { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }
        public double Price { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; }
        public int BookingId { get; set; }
        public int Roomnum { get; set; }
    }
}
