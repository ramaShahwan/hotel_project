using OurHotels.Dto.Hotel;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.IRepo
{
    public interface IRoomRepo
    {
        public Task AddRoom(AddRoomDto addRoomDto, string userId);
        public Task Addsuit(AddRoomDto addRoomDto, string userId);
        public RoomDto GetRoombyId(int RoomId);
        public void DeleteRoom(int roomId);
        //public void Addsuit(AddRoomDto addRoomDto, string userId);
        public void EditRoomD(int RoomId, EditRoomDto editRoom);

    }
}
