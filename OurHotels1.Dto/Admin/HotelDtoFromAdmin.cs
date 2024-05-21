using OurHotels.Dto.Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Admin
{
   public class HotelDtoFromAdmin
    {

        public int HotelEntityId { get; set; }
        public string HotelName { get; set; }
        public string ManagerName { get; set; }
        public string HotelAddress { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public int numOfStars { get; set; }
        public string ManegerPhone { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Description { get; set; }
        [MaxLength]
        public byte[] HotelPicture { get; set; }
        [MaxLength]
        public byte[] IdentityCertifcate { get; set; }
     
    }
}
