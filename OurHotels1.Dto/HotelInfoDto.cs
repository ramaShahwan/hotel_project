using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto
{
    public class HotelInfoDto
    {
        public byte[] HotelPicture { get; set; }
        public string HotelName { get; set; }
        public string HotelCity { get; set; }
        public int HotelStars { get; set; }
    }
}
