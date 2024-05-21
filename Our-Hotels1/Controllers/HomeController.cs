using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using My_Tables.Entities;
using Our_Hotels1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyDbProject;
using System.Security.Claims;
using OurHotels.Dto.Hotel;
using Newtonsoft.Json;
using OurHotels.Dto.Customer;
using OurHotels.Dto.Room;
using Microsoft.EntityFrameworkCore;
using OurHotels.Dto;

namespace Our_Hotels1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        public readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ILogger<HomeController> logger, UserManager<UserEntity> userManager,
          ApplicationDbContext applicationDbContext, SignInManager<UserEntity> signInManager
            )
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var res = _applicationDbContext.Hotels.Select(s => new HotelInfoDto
            {
                HotelPicture = s.HotelPicture,
                HotelName = s.HotelName,
                HotelCity = s.City.ToString(),
                HotelStars = s.numOfStars
            }).ToList();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            if (x != null)
            {
                if (x.Id != null)
                {
                    var type = _applicationDbContext.Users.Where(s => s.Id == x.Id)
                     .Select(m => m.UserType).FirstOrDefault();
                    if (type == My_Tables.Entities.Type_Of.Hotel)
                    {
                        Program.loginUserDto.type_Of = "Hotel";
                    }
                    else if (type == My_Tables.Entities.Type_Of.Customer)
                    {
                        Program.loginUserDto.type_Of = "Customer";
                    }
                    else
                    {
                        Program.loginUserDto.type_Of = "Admin";
                    }

                }
            }

            else
            {
                return View(res);
            }
            ViewData["AllServices"]= _applicationDbContext.Hotel_Extras.Select(s => new AllservDto{  name = s.Extra_ServicesName, photo = s.Extra_ServicesPicture }).ToList();
            //return View("Index", res);
            return View(res);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

                }
                else if (Program.loginUserDto.type_Of == "Customer")
                {
                    var UserEntityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Program.CustomerName = _applicationDbContext.Customers.Where(n => n.UserEntityId == UserEntityId)
                        .Select(n => new { n.FirstName, n.LastName }).FirstOrDefault().ToString();
                }

            }

        }
        [HttpPost]
        public IActionResult Search([FromBody] SearchDto searchDto)
        {

            var from = DateTime.ParseExact(searchDto.from, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var to = DateTime.ParseExact(searchDto.to, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var cityEnum = Enum.Parse(typeof(My_Tables.Entities.City), searchDto.city, true);
            List<HotelDetailsDto> filteredHotels = new List<HotelDetailsDto>();

            foreach (var item in searchDto.rooms)
            {
                int numOfBeds = item.numBeds;
                var filtered = _applicationDbContext.Hotels
               .Where(hotel => hotel.HotelName == searchDto.hotelName && hotel.City == (My_Tables.Entities.City)cityEnum)
               .Select(hotel => new HotelDetailsDto
               {
                   HotelName = hotel.HotelName,
                   NumOfStars = hotel.numOfStars,
                   City = (OurHotels.Dto.Hotel.City)hotel.City,
                   HotelPicture = hotel.HotelPicture,
                   HotelAddress = hotel.HotelAddress,
                   Rooms = hotel.RoomEntities
                        .Where(room => room.numOfBeds == numOfBeds)
                            .Select(room => new RoomDetailsDto
                            {
                                RoomEntityId = room.RoomEntityId,
                                NumOfBeds = room.numOfBeds,
                                Price = room.Price,
                                Suite = room.suite,
                                RoomImagesUrls = room.Images.Select(image => new RoomImageDto
                                {
                                    Id = image.Id,
                                    Url = image.Url,
                                    RoomEntityId = image.RoomEntityId
                                }).ToList()
                            })
                            .ToList()
               })
                    .ToList();
                if (filtered.Any(hotel => hotel.Rooms.Any()))
                {
                    filteredHotels.AddRange(filtered);
                }
            }
            string url = Url.Action("SearchHotels", "Customer");

            // Return the URL as JSON response
            return Json(new { RedirectUrl = url });
           // return View("testing");
           // return View("SearchHotelwithNoLog", filteredHotels);

        }
        public ActionResult LoadRoomsInfo()
        {
            var res = selectedRoomIds;
            return View();
        }
        private List<int> selectedRoomIds = new List<int>();
        [HttpPost]
        public ActionResult SaveSelectedRoomId(int roomId)
        {
            try
            {
                List<int> selectedRooms;
                var storedValue = HttpContext.Session.GetString("SelectedRooms");

                if (string.IsNullOrEmpty(storedValue))
                {
                    selectedRooms = new List<int> { roomId };
                }
                else
                {
                    selectedRooms = JsonConvert.DeserializeObject<List<int>>(storedValue);
                    selectedRooms.Add(roomId);
                }

                HttpContext.Session.SetString("SelectedRooms", JsonConvert.SerializeObject(selectedRooms));
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        public IActionResult GetAllHotels()
        {
            var res = _applicationDbContext.Hotels.Select(s => new HotelInfoDto{
              HotelPicture=  s.HotelPicture,
              HotelName=  s.HotelName,
              HotelCity =  s.City.ToString(), 
             HotelStars=    s.numOfStars }).ToList();
            return View("Index",res);
        }
      
    }
            

}
public class AllservDto
{
    public string name { get; set; }
    public byte[] photo { get; set; }
}