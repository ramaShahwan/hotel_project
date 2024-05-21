using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using My_Tables.Entities;
using MyDbProject;
using NToastNotify;
using OurHotel.IRepo;
using OurHotel1.Repo.My_Ex;
using OurHotels.Dto.Hotel;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Our_Hotels1.Controllers
{
    public class HotelController : Controller
    {
        public readonly ApplicationDbContext _applicationDbContext;
        private readonly IToastNotification _toastNotification;
        private readonly IHotelRepo _Ihotel;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ILogger<LogoutModel> _logger;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;
        private string firstname;
        private string lastname;
        private int phonenumber;
        private double bookingPrice;

        public HotelController(ILogger<LogoutModel> logger, UserManager<UserEntity> userManager, IHotelRepo Ihotel, ApplicationDbContext applicationDbContext, IToastNotification toastNotification, IRoomRepo IRoom, SignInManager<UserEntity> signInManager)
        {
            this._Ihotel = Ihotel;
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
            _toastNotification = toastNotification;
            _userManager = userManager;
            _logger = logger;
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
        public async Task<IActionResult> HotelProfileSettingAsync(AddHotelDto addHotelDto)
        {
            //   var ss= _applicationDbContext.Hotels.Where()
            if (ModelState.IsValid)
            {
                try
                {
                    if (addHotelDto.City.ToString() == 0 + "")
                    {
                        ModelState.AddModelError("addHotelDto.City", "This field must be required ");
                        return View(addHotelDto);
                    }
                    if (addHotelDto.numOfStars.ToString() == " ")
                    {
                        ModelState.AddModelError("addHotelDto.numOfStars", "This field must be required ");
                        return View(addHotelDto);
                    }
                    if (Request.Form.Files.Count > 0)
                    {
                        var file = Request.Form.Files[0];
                        var file1 = Request.Form.Files[1];
                        var dataStream = new MemoryStream();

                        var datastream1 = new MemoryStream();

                        file.CopyTo(dataStream);

                        file1.CopyTo(datastream1);
                        var l = dataStream.ToArray();
                        var l1 = datastream1.ToArray();
                        if (l.Length > _maxAllowedPosterSize || l1.Length > _maxAllowedPosterSize)
                        {
                            ModelState.AddModelError("Poster", "Image cannot be more than 1 MB!");
                            return View("addHotelDto");
                        }
                        _Ihotel.AddHotel(addHotelDto, l, l1);
                        // await _userManager.UpdateAsync(user);
                    }
                    _toastNotification.AddSuccessToastMessage("Your order is processing... ");
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignOutAsync();
                    _logger.LogInformation("User logged out.");
                    Program.loginUserDto.type_Of = null;
                    Program.AddUserDto.UserType = null;
                    return Redirect("/Identity/Account/Register");
                }
                catch (NameEx)
                {
                    ModelState.AddModelError("nameof(addHotelDto.HotelName)", "This hotel name is exist");
                    return View(addHotelDto);
                }
            }
            else
                return View(addHotelDto);
        }
        public async Task<IActionResult> RoomsList()
        {
            LayoutInfo();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var hotelId = _applicationDbContext.Hotels.Where(n => n.UserEntityId == x.Id)
                        .Select(n => n.HotelEntityId).FirstOrDefault();
            var res = _Ihotel.GetAllRooms(hotelId);

            //foreach (var im in res)
            //{
            //    foreach(var image in im.Images)
            //    {
            //        var url = image.Url;
            //        var imageAfterCrop = url.Split("wwwroot").ElementAt(1);
            //    }
            //}
            return View("AllRooms", res);
        }


        public async Task<IActionResult> SuitsList()
        {
            LayoutInfo();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var hotelId = _applicationDbContext.Hotels.Where(n => n.UserEntityId == x.Id)
                        .Select(n => n.HotelEntityId).FirstOrDefault();
            var res = _Ihotel.GetAllSuits(hotelId);
            return View("AllSuits", res);
        }
        //[HttpGet]
        //[HttpPost]
        public async Task<IActionResult> EditHotelProfileSettingAsync(EditHotelDto editHotelDto)
        {

            LayoutInfo();

            var x = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["Email"] = await _userManager.GetEmailAsync(x);
            var hotelId = _applicationDbContext.Hotels.Where(n => n.UserEntityId == x.Id)
                        .Select(n => n.HotelEntityId).FirstOrDefault();

            Program.HotelIdentity =
                  _applicationDbContext.Hotels.Where(u => u.UserEntityId == x.Id)
                  .Select(u => u.IdentityCertifcate).FirstOrDefault();


            ViewData["EditHotelProfileSetting"] = _Ihotel.HotelProfileSettingInfo(x.Id);


            var hotelPhoto = _applicationDbContext.Hotels
                    .Where(h => h.HotelEntityId == hotelId)
                    .Select(h => h.HotelPicture).FirstOrDefault();

            if (ModelState.IsValid)
            {


                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files.FirstOrDefault();

                    //check file size and extension

                    using (var dataStream = new MemoryStream())
                    {

                        await file.CopyToAsync(dataStream);
                        editHotelDto.HotelPicture = dataStream.ToArray();
                        //    hotelPhoto = editHotelDto.HotelPicture;

                        // _applicationDbContext.SaveChanges();
                    }
                    _Ihotel.EditeHotel(hotelId, editHotelDto);

                }
                else
                {
                    _Ihotel.EditeHotel2(hotelId, editHotelDto);

                }
                _toastNotification.AddSuccessToastMessage(" Information updated. ");
                return RedirectToAction("Index", "Home");
            }

    else
        return View(editHotelDto);

}
        public async Task<IActionResult> AddHotelServiceAsync(Hotel_ExtraDto hotel_ExtraDto)
        {
            LayoutInfo();
            byte[] ServPhoto = null;
            var x = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];

                    var dataStream = new MemoryStream();
                    file.CopyTo(dataStream);

                    ServPhoto = dataStream.ToArray();
                }

                _Ihotel.AddServices(x.Id, hotel_ExtraDto, ServPhoto);
                _toastNotification.AddSuccessToastMessage(hotel_ExtraDto.Name + " service added. ");
            }
            return View("AddHotelService", " ");
        }
        public async Task<IActionResult> AllServicesAsync()
        {
            LayoutInfo();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var hotelId = _applicationDbContext.Hotels.Where(n => n.UserEntityId == x.Id)
            .Select(n => n.HotelEntityId).FirstOrDefault();
            var res = _applicationDbContext.Hotel_Extras.Where(s => s.HotelEntityId == hotelId).Select(s => new Hotel_ExtraDto
            {
                Hotel_ExtraEntityId = s.Hotel_ExtraEntityId,
                Date = s.Date,
                Price = s.Price,
                Description = s.Description,
                Name = s.Extra_ServicesName,
                ServicePhoto = s.Extra_ServicesPicture,
                //Extra_ServiceEntityId=  s.Extra_ServicesEntityId
            }

                ).ToList();

            return View("ServicesList", res);
        }

        public async Task<IActionResult> DeletService(int id)
        {
            var serv = _applicationDbContext.Hotel_Extras.Where(s => s.Hotel_ExtraEntityId == id).FirstOrDefault();
            _applicationDbContext.Remove(serv);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("AllServices"); // Redirect to the appropriate action/view
        }

        public async Task<IActionResult> EditService(int id)
        {
            LayoutInfo();

           
                ViewData["Services"] = _applicationDbContext.Hotel_Extras.Where(s => s.Hotel_ExtraEntityId == id)
                 .Select(s => new Hotel_ExtraDto
                 {
                     Hotel_ExtraEntityId = s.Hotel_ExtraEntityId,
                     Date = s.Date,
                     Price = s.Price,
                     Description = s.Description,
                     Name = s.Extra_ServicesName,
                     ServicePhoto = s.Extra_ServicesPicture,
                     HotelEntityId = s.HotelEntityId
                 }

                    ).FirstOrDefault();


                return View(ViewData["Services"]);
           
             

            
        }
        public IActionResult EditService2(int id, EditService hotel_ExtraDto)
        {
            LayoutInfo();
            var res = _applicationDbContext.Hotel_Extras.Where(s => s.Hotel_ExtraEntityId == id).FirstOrDefault();
            if (!string.IsNullOrEmpty(hotel_ExtraDto.Name))
            {
                res.Extra_ServicesName = hotel_ExtraDto.Name;
            }
            if (!string.IsNullOrEmpty(hotel_ExtraDto.Description))
            {
                res.Description = hotel_ExtraDto.Description;
            }
            //if (hotel_ExtraDto.Price != 0)
            //{
            res.Price = hotel_ExtraDto.Price;
            //}
            if (Request.Form.Files.Count > 0)
            {
                var res1 = _applicationDbContext.Hotel_Extras.Where(s => s.Hotel_ExtraEntityId == id).FirstOrDefault();
                var file = Request.Form.Files[0];

                var dataStream = new MemoryStream();
                file.CopyTo(dataStream);

                res1.Extra_ServicesPicture = dataStream.ToArray();
                _applicationDbContext.SaveChanges();
            }
            _applicationDbContext.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Your service updated. ");
            return RedirectToAction("AllServices");
        }
        public IActionResult search(string name)
        {
            ViewData["search"] = _applicationDbContext.Hotel_Extras.Where(s => s.Extra_ServicesName.ToLower() == name.ToLower()).FirstOrDefault();
            return View("AllServices", ViewData["search"]);
        }
        [HttpGet]
        [Route("api/hotels")]
        public IActionResult GetHotelNames()
        {
            var hotelNames = _applicationDbContext.Hotels.Select(s => s.HotelName).ToList();
            return Ok(hotelNames);
        }
      //dashboard
        public async Task<IActionResult> GetHotelReviewsAsync(DateTime? from, DateTime? to)
        {
            LayoutInfo();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var hotelId = _applicationDbContext.Hotels.Where(n => n.UserEntityId == x.Id).Select(n => n.HotelEntityId).FirstOrDefault();

            var hotelReviews = _applicationDbContext.Bookings
.Where(booking => booking.RoomEntity.HotelEntity.HotelEntityId == hotelId)
.Select(booking => new HotelReviewDto
{
 CustomerName = booking.BillEntity.CustomerEntity.FirstName + " " + booking.BillEntity.CustomerEntity.LastName,
 mobile = booking.BillEntity.CustomerEntity.phoneNumber,
 BookingDate = booking.BillEntity.Date,
 CheckInDate = booking.checkIn,
 CheckOutDate = booking.checkOut,
 Price = booking.Price,
 Reviews = booking.Reviews ?? "",
 Rating = booking.Rate.HasValue ? booking.Rate.Value : 0

}).OrderBy(n => n.CustomerName).ThenBy(m => m.BookingDate)
.ToList();
            if (from != null && to != null)
                hotelReviews = hotelReviews.Where(s => s.BookingDate >= from && s.BookingDate <= to).ToList();
            ViewData["from"] = from;
            ViewData["to"] = to;

            return View(hotelReviews);
        }
        public async Task<IActionResult> GetHotelHistoryAsync()
        {
            LayoutInfo();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var hotelId = _applicationDbContext.Hotels.Where(n => n.UserEntityId == x.Id).Select(n => n.HotelEntityId).FirstOrDefault();
            var bookingInfo = _applicationDbContext.Bookings
     .Where(b => b.RoomEntity.HotelEntityId == hotelId)
     .GroupBy(m => new 
     {
         BillDate = m.BillEntity.Date,
         CustomerId = m.BillEntity.CustomerEntityId,
         CustomerFirstName = m.BillEntity.CustomerEntity.FirstName, // Replace "Name" with the actual property name
         CustomerlastName = m.BillEntity.CustomerEntity.LastName ,
         CustomerMobile = m.BillEntity.CustomerEntity.phoneNumber,
         // Replace "Name" with the actual property name
    })
     .Select(group => new HotelHistoryDto
     {
         BillDate = group.Key.BillDate,
         CustomerId = group.Key.CustomerId,
         CustomerFirstName = group.Key.CustomerFirstName,
         CustomerlastName = group.Key.CustomerlastName,
         CustomerMobile = group.Key.CustomerMobile,
         TotalPrice = group.Sum(b => b.Price) // Replace "Price" with the actual property name
    })
     .ToList();
            return View(bookingInfo);
        }
        
    }
}

public class HotelHistoryDto
{
    public DateTime BillDate { get; set; }
    public int CustomerId { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerlastName { get; set; }
    public double TotalPrice { get; internal set; }
    public int CustomerMobile { get; internal set; }
}