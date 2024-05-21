using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Customer
{
   public class RoomsBookedDto
    {
        public string HotelName { get; set; }
        public int RoomNumber { get; set; }
        public int RoomBed { get; set; }
        public double BookingPrice { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
