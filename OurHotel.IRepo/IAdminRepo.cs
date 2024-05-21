using OurHotels.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.IRepo
{
   public interface IAdminRepo
    {
        public ProfileAdminDto GetAdminInfo();
        public void AddAdminProfile(AddAdminProfileDto addAdminProfileDto, byte[] l);
        public void AddAdminProfile(AddAdminProfileDto addAdminProfileDto);
        public List<HotelDtoFromAdmin> GetAllHotel();
        public List<HotelDtoFromAdmin> GetAllHotelAdmin();
        public void UpdateHotelForAdmin(int HotelEntityId, HotelDtoFromAdmin Updatedto);
        public List<HotelDtoFromAdmin> SearchHotelsByName(String Fullname);

    }
}
