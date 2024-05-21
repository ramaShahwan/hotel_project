using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotels.Dto.Hotel
{
  public class EditService
    {
        
        public int Hotel_ExtraEntityId { get; set; }
       
        public string Name { get; set; }

       
     
        public int HotelEntityId { get; set; }



        public double Price { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public byte[] ServicePhoto { get; set; }

        //one to many relation
        //  public virtual ICollection<Booking_ExtraEntity> Booking_ExtraEntities { get; set; }
        // public virtual HotelEntity HotelEntity { get; set; }
        // public virtual Extra_ServicesDto  Extra_ServicesDto { get; set; }
    }
}
