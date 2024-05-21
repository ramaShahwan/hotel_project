using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Customer
{
    public class HotelServicesDto
    {
        public string Extra_ServicesName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public byte[] Extra_ServicesPicture { get; set; }
    }
}
