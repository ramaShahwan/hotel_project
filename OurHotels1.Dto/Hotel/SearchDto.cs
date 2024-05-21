using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
   public class SearchDto
    {

        

            public string city { get; set; }
            public string hotelName { get; set; }
            public string from { get; set; }
            public string to { get; set; }

            public List<RoomModel> rooms { get; set; }
        }

        public class RoomModel
        {
            public string roomNumber { get; set; }
            public int numBeds { get; set; } 
        }
    }

