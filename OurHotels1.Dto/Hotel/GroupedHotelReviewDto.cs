using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
    public class GroupedHotelReviewDto
    {
        public string CustomerName { get; set; }
        public int mobile { get; set; }
        public int Mobile { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalCount { get; set; }
        public List<HotelReviewDto> Bookings { get; set; }
    }
}
