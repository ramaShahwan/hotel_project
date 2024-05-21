using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto
{
    public class BookingResult
    {
        public DateTime BookingDate { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string phoneNumber { get; set; }
        public int PhoneNumber { get; set; }
        public double TotalBillPaid { get; set; }
        public int CustomerEntityId { get; set; }
        
    }

}
