using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
  public class HotelReviewDto
    {
        public int mobile;

        public string CustomerName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Reviews { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public DateTime BookingDate { get; set; }
        public int Mobile { get; set; }
    }
}
