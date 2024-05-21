using OurHotels.Dto.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Customer
{
   public class HotelDetailsDto
    {
        public string HotelName { get; set; }
        public int NumOfStars { get; set; }
        public City City { get; set; }
        public byte[] HotelPicture { get; set; }
        public string HotelAddress { get; set; }
        public List<RoomDetailsDto> Rooms { get; set; }
     //   public RoomDetailsDto Room{ get; set; }
        public string HotelDesccription { get; set; }
    }
}
