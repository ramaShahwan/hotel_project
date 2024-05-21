using OurHotels.Dto.Hotel;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Customer
{
   public class RoomDetailsDto
    {
        public string height;
        public string width;
        public double pric2;
        public string floor;
        public int phone;

        public int RoomEntityId { get; set; }
        public int RoomNum { get; set; }
        public bool Suite { get; set; }
        public int? NumOfBeds { get; set; }
        public double Price { get; set; }
        public List<RoomImageDto> RoomImagesUrls { get; set; }
        public int HotelEntityId { get; set; }
        public string HotelName { get; set; }
        public string Sea { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public int NumOfStars { get; set; }
        public byte[] HotelPicture { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public object AvgRating { get; set; }
        public int NumOfReviews { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsNotAvailable { get; set; }
        public string D1 { get; set; }
        public string D2 { get; set; }
        public HotelDetailsDto Hotel { get; set; }
    }
}
