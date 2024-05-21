﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Tables.Entities
{
   public class Hotel_ExtraEntity
    {

      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Hotel_ExtraEntityId { get; set; }

        [Required]
        [ForeignKey("Hotels")]
        public int HotelEntityId { get; set; }
        //[ForeignKey("Extrasirvices")]
        //public int Extra_ServicesEntityId { get; set; }
        //  [Required]
        //[ForeignKey("Extra_Services")]
        //public Guid Extra_ServiceEntityId { get; set; }

        [Required]
        public double Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required, MaxLength(50)]
        public string Extra_ServicesName { get; set; }
        [Display(Name = "Extra Services Picture")]
        public byte[] Extra_ServicesPicture { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        //one to many relation
        public virtual ICollection<Booking_ExtraEntity> Booking_ExtraEntities { get; set; }
        public virtual HotelEntity HotelEntity { get; set; }
      //  public virtual Extra_ServicesEntity Extra_ServicesEntity { get; set; }

    }
}
