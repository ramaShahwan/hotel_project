using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using My_Tables.Entities;
using MyDbProject;
using NToastNotify;
using OurHotel.IRepo;
using OurHotels.Dto;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Our_Hotels1.Controllers
{
    public class RoomController : Controller
    {
        public readonly ApplicationDbContext _applicationDbContext;
        private readonly IToastNotification _toastNotification;
        private readonly IRoomRepo _Iroom;
        private readonly IHostEnvironment hostEnvironment;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public RoomController(ApplicationDbContext applicationDbContext,
            IToastNotification toastNotification, UserManager<UserEntity> userManager, IRoomRepo iroom, SignInManager<UserEntity> signInManager, IHostEnvironment hostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            _toastNotification = toastNotification;
            _userManager = userManager;
            _Iroom = iroom;
            _signInManager = signInManager;
            this.hostEnvironment = hostEnvironment;
        }
        public void LayoutInfo()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (Program.loginUserDto.type_Of == "Hotel")
                {
                    var UserEntityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Program.HotelName = _applicationDbContext.Hotels.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => n.HotelName).FirstOrDefault();
                    Program.HotelCity = _applicationDbContext.Hotels.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => n.City).FirstOrDefault().ToString();
                    Program.HotelPic =
                        _applicationDbContext.Hotels.Where(u => u.UserEntityId == UserEntityId)
                        .Select(u => u.HotelPicture).FirstOrDefault();
                }
                else if (Program.loginUserDto.type_Of == "Customer")
                {
                    var UserEntityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Program.CustomerName = _applicationDbContext.Customers.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => new { n.FirstName, n.LastName }).FirstOrDefault().ToString();
                }

            }

        }
        public  async Task<IActionResult> AddSuit(AddRoomDto addRoomDto, int roomCount, List<IFormFile> Images)
        {
            LayoutInfo();
            // var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            // .Select(n => n.HotelName).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var filesDetails = await FileManagement.SaveFiles(Images.Select(i => new FileManagement.FileDetails
                {
                    File = i
                }).ToList()
                , hostEnvironment.ContentRootPath);
                var x = await _userManager.GetUserAsync(HttpContext.User);
                var hotelId = _applicationDbContext.Hotels.Where(s => s.UserEntityId == x.Id).Select(s => s.HotelEntityId).FirstOrDefault();

                var RoomNum = _applicationDbContext.RoomEntities
              .Any(r => r.RoomNum == addRoomDto.RoomNum && r.HotelEntityId == hotelId);
                if (RoomNum)
                {
                    ModelState.AddModelError("addRoomDto.RoomNum", "This room number is exist.. ");
                    return View(addRoomDto);
                }

                addRoomDto.ImageUrls = filesDetails.Select(x => x.Url).ToList();
                if(roomCount==0)
                {
                    roomCount = 1;
                }
                if (roomCount != 0)
                {
                    await _Iroom.Addsuit(addRoomDto, x.Id);
                }
                if (roomCount > 1)
                {
                    for (int i = 1; i < roomCount; i++)
                    {
                        ++addRoomDto.RoomNum;
                        ++addRoomDto.phone;
                        await _Iroom.Addsuit(addRoomDto, x.Id);
                    }
                }
                if (roomCount == 1)
                {
                    _toastNotification.AddSuccessToastMessage("Suit has added... ");

                }
                else
                {
                    _toastNotification.AddSuccessToastMessage(roomCount + " Suits added. ");

                }
                return View("AddSuit",addRoomDto);
            }
            // AddRoomIma
            // geDto addRoomImageDto = new AddRoomImageDto();
            return View("AddSuit", addRoomDto);

        }
        public async Task<IActionResult> AddRooms(AddRoomDto addRoomDto, int roomCount, List<IFormFile> Images)
        {

            LayoutInfo();
        
            if (ModelState.IsValid)
            {
                var filesDetails =  await FileManagement.SaveFiles(Images.Select(i => new FileManagement.FileDetails
                {
                    File = i
                }).ToList()
                , hostEnvironment.ContentRootPath);
                var x = await _userManager.GetUserAsync(HttpContext.User);
                var hotelId = _applicationDbContext.Hotels.Where(s => s.UserEntityId == x.Id).Select(s => s.HotelEntityId).FirstOrDefault();

                var RoomNum = _applicationDbContext.RoomEntities
               .Any(r => r.RoomNum == addRoomDto.RoomNum && r.HotelEntityId == hotelId);
                if (RoomNum)
                {
                    ModelState.AddModelError("addRoomDto.RoomNum", "This room number is exist.. ");
                    return View(addRoomDto);
                }
               
                addRoomDto.ImageUrls = filesDetails.Select(x => x.Url).ToList();
                if(roomCount==0)
                {
                    roomCount = 1;
                }
                if (roomCount != 0)
                {
                    await _Iroom.AddRoom(addRoomDto, x.Id);
                }
                if (roomCount > 1)
                {                    
                    for (int i = 1; i < roomCount; i++)
                    {
                        ++addRoomDto.RoomNum;
                        ++addRoomDto.phone;
                        await _Iroom.AddRoom(addRoomDto, x.Id);
                    }
                }
                if(roomCount == 1)
                {
                    _toastNotification.AddSuccessToastMessage("Room has added... ");

                }
                else
                {
                    _toastNotification.AddSuccessToastMessage(roomCount +" Rooms added. ");

                }
                return View(addRoomDto);
            }
            // AddRoomIma
            // geDto addRoomImageDto = new AddRoomImageDto();
            return View(addRoomDto);
        }
       // [HttpPost]
        public async Task<IActionResult> EditRoom(int Id,EditRoomDto editRoom, List<IFormFile> Images)
        {
            LayoutInfo();
            var l=editRoom.RoomNum;
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var hotelId = _applicationDbContext.Hotels.Where(s => s.UserEntityId == x.Id).Select(s => s.HotelEntityId).FirstOrDefault();
            //var RoomNum = _applicationDbContext.RoomEntities
            // .Any(r => r.RoomNum == editRoom.RoomNum && r.HotelEntityId == hotelId && editRoom.RoomNum !=l  );
            //if (RoomNum)
            //{
            //    ModelState.AddModelError("editRoom.RoomNum", "This room number is exist.. ");
            //    return View(editRoom);
            //}

            if (editRoom.RoomSizeW == null && editRoom.RoomSizeH == null && editRoom.RoomDirection2 == null 
                && editRoom.RoomDirection1== null && editRoom.Price ==null && editRoom.phone== null 
                && editRoom.numOfBeds == null && editRoom.suite ==null && editRoom.Floor == null
                )
            {
                ViewData["GetRoomById"] = _Iroom.GetRoombyId(editRoom.RoomId);
                //  var res = _Iroom.GetRoombyId(editRoom.RoomId);
                return View("EditRoom", ViewData["GetRoomById"]);
            }
            var filesDetails = await FileManagement.SaveFiles(Images.Select(i => new FileManagement.FileDetails
            {
                File = i
            }).ToList()
               , hostEnvironment.ContentRootPath);
            editRoom.ImageUrls= filesDetails.Select(x => x.Url).ToList();
            _Iroom.EditRoomD(Id, editRoom);
           
            
                _toastNotification.AddSuccessToastMessage("Room updated successfully.");
              return RedirectToAction("RoomsList", "Hotel");
         //   return Json(new { message = "Room updated successfully" });


        }
        public async Task<IActionResult> EditSuit(int Id, EditRoomDto editRoom, List<IFormFile> Images)
        {
            LayoutInfo();
            if (editRoom.RoomSizeW == null && editRoom.RoomSizeH == null && editRoom.RoomDirection2 == null
                && editRoom.RoomDirection1 == null && editRoom.Price == null && editRoom.phone == null
                && editRoom.numOfBeds == null && editRoom.suite == null && editRoom.Floor == null
                )
            {
                ViewData["GetRoomById"] = _Iroom.GetRoombyId(editRoom.RoomId);
                //  var res = _Iroom.GetRoombyId(editRoom.RoomId);
                return View(ViewData["GetRoomById"]);
            }
            var filesDetails = await FileManagement.SaveFiles(Images.Select(i => new FileManagement.FileDetails
            {
                File = i
            }).ToList()
               , hostEnvironment.ContentRootPath);
            editRoom.ImageUrls = filesDetails.Select(x => x.Url).ToList();
            _Iroom.EditRoomD(Id, editRoom);
           
                _toastNotification.AddSuccessToastMessage("Suit updated successfully.");
                return RedirectToAction("SuitsList", "Hotel");
           

        }

        public IActionResult DeleteRoom(int RoomId)
        {
            _Iroom.DeleteRoom(RoomId);
      
           
                _toastNotification.AddSuccessToastMessage("Room has deleted... ");
                return RedirectToAction("RoomsList", "Hotel");
            
           
            
        }
        public IActionResult DeleteSuit(int RoomId)
        {
            _Iroom.DeleteRoom(RoomId);


            _toastNotification.AddSuccessToastMessage("Suit has deleted... ");
            return RedirectToAction("SuitsList", "Hotel");



        }
        

    }
}