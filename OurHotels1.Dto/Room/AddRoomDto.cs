﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OurHotels.Dto.Room
{
   public class AddRoomDto
    {
        [Key]
        public int RoomEntityId { get; set; }
       //[Required]
       [ForeignKey("Hotels")]
       public int HotelEntityId { get; set; }

       [Range(0, 6) ]
        public int? numOfBeds { get; set; }
      
        // public int ExtraBedLimit { get; set; }

        [Required]
        public int? phone { get; set; }

        [Required]
        public int? RoomNum { get; set; }
        // to reach price from any date
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string RoomSizeW { get; set; }// width
        public string RoomSizeH { get; set; }//height
        public string RoomDirection1 { get; set; }// N S
        public string RoomDirection2 { get; set; }// E W
        public bool? suite { get; set; }
        public string spouseBeds { get; set; }
        public string sea { get; set; }
        public int? numOfRoom { get; set; }
        [Required]
        public double? Price { get; set; }
        public string Floor { get; set; }
        public List<string> ImageUrls { get; set; }
         public AddRoomImageDto AddRoomImageDto { get; set; }
    }
}
