using OurHotels.Dto.Admin;
using OurHotels.Dto.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.IRepo
{
   public interface IHotelRepo
    {
        public void AddHotel(AddHotelDto addHotelDto, byte[] l, byte[] l1);
        public void AddHotelFromAdmin(AddHotelFromAdminDto addDto ,string UserId);
        public void UpdateHotel(HotelDto Updatedto);
        public void DeleteHotel(int id);
        public HotelDto GetHotelById(int id);
        public HotelDtoFromAdmin GetHotelById2(int id);
        public int GetHotelCount();
        public List<HotelDto> GetAllHotel();
        public HotelDto HotelProfileSettingInfo(string id);
        public void EditeHotel(int hotelId, EditHotelDto Updatedto);
        public void EditeHotel2(int hotelId, EditHotelDto Updatedto);
        public List<RoomDto> GetAllRooms(int hotelId);
        public List<RoomDto> GetAllSuits(int hotelId);
        public void UpdateHotelForAdmin(HotelDtoFromAdmin Updatedto);
      public  void AddServices(string id, Hotel_ExtraDto hotel_ExtraDto,byte[] ServPhoto);
    }
}
