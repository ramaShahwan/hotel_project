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
using OurHotels.Dto.Customer;
using OurHotels.Dto.Room;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Our_Hotels1.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ApplicationDbContext _applicationDbContext;
        private readonly IToastNotification _toastNotification;
        private readonly ICustomerRepo _Icustomer;
        private readonly IHostEnvironment hostEnvironment;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public CustomerController(ApplicationDbContext applicationDbContext,
            IToastNotification toastNotification, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IHostEnvironment hostEnvironment, ICustomerRepo Icustomer)
        {
            _applicationDbContext = applicationDbContext;
            _toastNotification = toastNotification;
            _userManager = userManager;
            _Icustomer = Icustomer;
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

        public async Task<IActionResult> SearchHotelAsync(string cityName, int? numOfStars, int? numOfBeds, string hotelName, DateTime? checkInDate, DateTime? checkOutDate, string price,String type)
        {

            var filtered = new List<HotelDetailsDto>();
            if (!_signInManager.IsSignedIn(User))

            {
                filtered = _applicationDbContext.Hotels
              .Where(s => s.State != 0)
   .Select(hotel => new HotelDetailsDto
   {
       HotelName = hotel.HotelName,
       NumOfStars = hotel.numOfStars,
       City = (OurHotels.Dto.Hotel.City)hotel.City,
       HotelPicture = hotel.HotelPicture,
       HotelAddress = hotel.HotelAddress,
       HotelDesccription = hotel.Description,
       Rooms = hotel.RoomEntities
           .Select(room => new RoomDetailsDto
           {
               RoomEntityId = room.RoomEntityId,
               NumOfBeds = room.numOfBeds,
               Price = room.Price,
               pric2 = room.Price2,
               Suite = room.suite,
                //

                IsNotAvailable = _applicationDbContext.Bookings
                  .Any(booking =>
                          booking.RoomEntityId == room.RoomEntityId &&
                          (
                              (booking.checkIn <= checkInDate && booking.checkOut >= checkInDate) // the orange case
                              || (booking.checkIn <= checkOutDate && booking.checkOut >= checkOutDate) // the red case (and the yellow case)
                              || (booking.checkIn >= checkInDate && booking.checkOut <= checkOutDate) // the white case (and the yellow case)
                          )
                          &&
                          (
                              booking.BillEntity.Active == false
                          )
                      ),

                //
                RoomImagesUrls = room.Images.Select(image => new RoomImageDto
               {
                   Id = image.Id,
                   Url = image.Url,
                   RoomEntityId = image.RoomEntityId
               }).ToList(),
               AvgRating = _applicationDbContext.Bookings
                   .Where(booking => booking.RoomEntityId == room.RoomEntityId && booking.Rate.HasValue)
                   .Average(booking => booking.Rate),
               NumOfReviews = _applicationDbContext.Bookings
                   .Count(booking => booking.RoomEntityId == room.RoomEntityId && !string.IsNullOrEmpty(booking.Reviews))
           })
   .Where(l => l.IsNotAvailable == false)
           .ToList()
   })
   .ToList();

            }
            else
            {
                var x = await _userManager.GetUserAsync(HttpContext.User);
                var CustmerId = _applicationDbContext.Customers.Where(n => n.UserEntityId == x.Id)
                    .Select(n => n.CustomerEntityId).FirstOrDefault();
                DateTime currentDate = DateTime.Today;

                if (checkInDate == null && checkOutDate == null)
                {
                    checkInDate = DateTime.Today;
                    checkOutDate = currentDate.AddDays(1);
                }
                filtered = _applicationDbContext.Hotels
                   .Where(s => s.State != 0)
        .Select(hotel => new HotelDetailsDto
        {
            HotelName = hotel.HotelName,
            NumOfStars = hotel.numOfStars,
            City = (OurHotels.Dto.Hotel.City)hotel.City,
            HotelPicture = hotel.HotelPicture,
            HotelAddress = hotel.HotelAddress,
            HotelDesccription = hotel.Description,
            Rooms = hotel.RoomEntities
                .Select(room => new RoomDetailsDto
                {
                    RoomEntityId = room.RoomEntityId,
                    NumOfBeds = room.numOfBeds,
                    Price = room.Price,
                    pric2 = room.Price2,
                    Suite = room.suite,
                 //

                 IsNotAvailable = _applicationDbContext.Bookings
                       .Any(booking =>
                               booking.RoomEntityId == room.RoomEntityId &&
                               (
                                   (booking.checkIn <= checkInDate && booking.checkOut >= checkInDate) // the orange case
                                   || (booking.checkIn <= checkOutDate && booking.checkOut >= checkOutDate) // the red case (and the yellow case)
                                   || (booking.checkIn >= checkInDate && booking.checkOut <= checkOutDate) // the white case (and the yellow case)
                               )
                               &&
                               (
                                   booking.BillEntity.Active == false || (booking.BillEntity.Active == true && booking.BillEntity.CustomerEntityId == CustmerId)
                               )
                           ),

                 //
                 RoomImagesUrls = room.Images.Select(image => new RoomImageDto
                    {
                        Id = image.Id,
                        Url = image.Url,
                        RoomEntityId = image.RoomEntityId
                    }).ToList(),
                    AvgRating = _applicationDbContext.Bookings
                        .Where(booking => booking.RoomEntityId == room.RoomEntityId && booking.Rate.HasValue)
                        .Average(booking => booking.Rate),
                    NumOfReviews = _applicationDbContext.Bookings
                        .Count(booking => booking.RoomEntityId == room.RoomEntityId && !string.IsNullOrEmpty(booking.Reviews))
                })
        .Where(l => l.IsNotAvailable == false)
                .ToList()
        })
        .ToList();
            }

            if (!string.IsNullOrEmpty(cityName))
            {
                filtered = filtered.Where(hotel => hotel.City.ToString() == cityName).ToList();
            }

            if (numOfStars.HasValue)
            {
                filtered = filtered.Where(hotel => hotel.NumOfStars == numOfStars).ToList();
            }
            if (price == "cheapest")
            {
                filtered = filtered.OrderBy(hotel => hotel.Rooms.Min(room => room.Price)).ToList();
            }
            else if (price == "highest")
            {
                // Handle the highest option
                filtered = filtered.OrderBy(hotel => hotel.Rooms.Max(room => room.Price)).ToList();
            }
            if (numOfBeds.HasValue)
            {
                filtered = filtered
                    .Select(hotel =>
                    {
                        hotel.Rooms = hotel.Rooms.Where(room => room.NumOfBeds == numOfBeds).ToList();
                        return hotel;
                    })
                    .OrderByDescending(hotel => hotel.Rooms.Any(room => room.NumOfBeds == numOfBeds)) // Hotels with matching beds first
                                                                                                      // .ThenBy(hotel => hotel.Rooms.Sum(room => room.NumOfBeds == numOfBeds ? 1 : 0)) // Order based on the number of matching beds
                    .ToList();
            }
            if (!string.IsNullOrEmpty(hotelName))
            {
                filtered = filtered.Where(hotel => hotel.HotelName.Contains(hotelName)).ToList();
            }
            if(!string.IsNullOrEmpty(type))
            {
                if(type== "suit")
                {
                    filtered = filtered
                       .Select(hotel =>
                       {
                           hotel.Rooms = hotel.Rooms.Where(room => room.Suite == true).ToList();
                           return hotel;
                       })
                       // .ThenBy(hotel => hotel.Rooms.Sum(room => room.NumOfBeds == numOfBeds ? 1 : 0)) // Order based on the number of matching beds
                       .ToList();
                }
                else
                {
                    filtered = filtered
                       .Select(hotel =>
                       {
                           hotel.Rooms = hotel.Rooms.Where(room => room.Suite == false).ToList();
                           return hotel;
                       })
                       // .ThenBy(hotel => hotel.Rooms.Sum(room => room.NumOfBeds == numOfBeds ? 1 : 0)) // Order based on the number of matching beds
                       .ToList();
                }
                
            }
            ViewData["SearchHotels"] = filtered;
            ViewData["From"] = checkInDate;
            ViewData["to"] = checkOutDate;
            return View(ViewData["SearchHotels"]);
        }
        //Customer DashBoard
        public async Task<IActionResult> GetBookingsForCustomer(DateTime? from, DateTime? to)
        {
            LayoutInfo();
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var CustmerId = _applicationDbContext.Customers.Where(n => n.UserEntityId == x.Id)
                        .Select(n => n.CustomerEntityId).FirstOrDefault();
            if (from == null && to == null)
            {
                var bookings = await _Icustomer.GetBookingsForCustomer(CustmerId);
                return View(bookings);

            }
            else
            {
                var bookings = await _Icustomer.GetBookingsForCustomerByDate(CustmerId, from, to);
                ViewData["from"] = from;
                ViewData["to"] = to;

                //  return RedirectToAction("GetBookingsForCustomer", from.ToString, to);
                return View(bookings);

            }
        }
        public async Task<IActionResult> CheckRoomAsync(int roomId)
        {
            var x = await _userManager.GetUserAsync(HttpContext.User);
            var CustmerId = _applicationDbContext.Customers.Where(n => n.UserEntityId == x.Id)
                        .Select(n => n.CustomerEntityId).FirstOrDefault();
            bool isRoomAlreadyAdded = _applicationDbContext.Bookings.Any(b =>
         b.RoomEntityId == roomId &&
         b.BillEntity.CustomerEntityId == CustmerId &&
         b.BillEntity.Active == true);
            return Json("", isRoomAlreadyAdded);
        }
        [HttpGet]
        public async Task<IActionResult> GetHotelDetailsByName(string cityName)
        {

            if (Enum.TryParse<City>(cityName, out var city))
            {
                var hotels = _applicationDbContext.Hotels
                    .Where(c => c.City == city)
                    .Where(c => c.State == State.confirmed)
                    .Select(c => c.HotelName)
                    .ToList();

                return Json(hotels);
            }
            else
            {
               
                return BadRequest("Invalid city name.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBookingInfo(int bookingId, int? rating, string review)
        {
            var booking = await _applicationDbContext.Bookings.FindAsync(bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            // Update the rating and review fields based on the provided values
            booking.Rate = rating;
            booking.Reviews = review;

            try
            {
                await _applicationDbContext.SaveChangesAsync();
                // return View("GetBookingsForCustomer");
                //  return Json(new { success = true, message = "Booking information updated successfully." });
                return RedirectToAction("GetBookingsForCustomer");
            }
            catch (DbUpdateException)
            {
                // Log the error or handle it accordingly
                return Json(new { success = false, message = "Error occurred while updating booking information." });
                //  return View("GetBookingsForCustomer");
            }
        }

         public async Task<ActionResult> AddforBookingAsync(int roomId, DateTime CheckinDate, DateTime CheckoutDate)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var customerId = _applicationDbContext.Customers
                    .Where(n => n.UserEntityId == user.Id)
                    .Select(n => n.CustomerEntityId)
                    .FirstOrDefault();
                if (user.Id == null)
                {
                    RedirectToPage("Login");
                }
                var room = _applicationDbContext.RoomEntities.FirstOrDefault(r => r.RoomEntityId == roomId);

                if (room != null)
                {
                    // Check if there are any existing bookings 

                    var IsNotAvailable = _applicationDbContext.Bookings
                     .Any(booking =>
                             booking.RoomEntityId == room.RoomEntityId &&
                             (
                                 (booking.checkIn <= CheckinDate && booking.checkOut >= CheckinDate) // the orange case
                                 || (booking.checkIn <= CheckoutDate && booking.checkOut >= CheckoutDate) // the red case (and the yellow case)
                                 || (booking.checkIn >= CheckinDate && booking.checkOut <= CheckoutDate) // the white case (and the yellow case)
                             )
                             &&
                             (
                                 booking.BillEntity.Active == false || (booking.BillEntity.Active == true && booking.BillEntity.CustomerEntityId == customerId)
                             )
                         );

                    if (IsNotAvailable)
                    {

                        return RedirectToAction("BookingConflict", "Error");
                    }


                    var customerBill = _applicationDbContext.Bills
                        .FirstOrDefault(b => b.CustomerEntityId == customerId && b.Active);

                    if (customerBill == null)
                    {
                        // If the customer does not have an active bill create
                        customerBill = new BillEntity
                        {
                            CustomerEntityId = customerId,
                            Date = DateTime.Now,
                            Active = true
                        };

                        _applicationDbContext.Bills.Add(customerBill);
                        await _applicationDbContext.SaveChangesAsync();
                    }


                    var booking = new BookingEntity
                    {
                        RoomEntityId = roomId,
                        BillEntityId = customerBill.BillEntityId,
                        checkIn = CheckinDate,
                        checkOut = CheckoutDate,
                        Price = room.Price,
                        BookingDate = DateTime.Now,

                    };

                    _applicationDbContext.Bookings.Add(booking);
                    await _applicationDbContext.SaveChangesAsync();

                    // Here, you may return a view or redirect to a confirmation page or perform other necessary actions.
                    //return View("BookingConfirmation");
                    return Json("");
                }

            }
          

            // Handle the case where the room is not found in the database
            return RedirectToAction("RoomNotFound", "Error");
        }
        [HttpGet]
        public async Task<IActionResult> ViewBookingfRoomsAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var customerId = _applicationDbContext.Customers
                .Where(n => n.UserEntityId == user.Id)
                .Select(n => n.CustomerEntityId)
                .FirstOrDefault();
            var bookedRooms = _applicationDbContext.Bills
            .Where(b => b.CustomerEntityId == customerId && b.Active == true)
            .Join(_applicationDbContext.Bookings,
                  bill => bill.BillEntityId,
                  booking => booking.BillEntityId,
                  (bill, booking) => new { Bill = bill, Booking = booking })
            .Join(_applicationDbContext.RoomEntities,
                  bb => bb.Booking.RoomEntityId,
                  room => room.RoomEntityId,
                  (bb, room) => new
                  {
                      HotelName = room.HotelEntity.HotelName,
                      RoomNumber = room.RoomNum,
                      RoomBed = room.numOfBeds,
                      // BookingPrice = bb.Booking.Price ?? 0.0,
                      CheckInDate = bb.Booking.checkIn,
                      CheckOutDate = bb.Booking.checkOut,
                      bookId = bb.Booking.BookingEntityId,
                      roomId = bb.Booking.RoomEntityId
                  })
            .ToList();
            bool IsNotAvailable;
            
            foreach ( var book in bookedRooms)
            {
                IsNotAvailable = _applicationDbContext.Bookings
                   .Any(booking =>
                           booking.RoomEntityId == book.roomId &&
                           (
                               (booking.checkIn <= book.CheckInDate && booking.checkOut >= book.CheckInDate) // the orange case
                               || (booking.checkIn <= book.CheckOutDate && booking.checkOut >= book.CheckOutDate) // the red case (and the yellow case)
                               || (booking.checkIn >= book.CheckInDate && booking.checkOut <= book.CheckOutDate) // the white case (and the yellow case)
                           )
                           &&
                           (
                               booking.BillEntity.Active == false)
                           );
                        
                if(IsNotAvailable)
                {
                 var res=   _applicationDbContext.Bookings.Where(b => b.BookingEntityId == book.bookId).FirstOrDefault();
                    _applicationDbContext.Remove(res);
                }

            }
            _applicationDbContext.SaveChanges();
            var bookedRooms1 = _applicationDbContext.Bills
          .Where(b => b.CustomerEntityId == customerId && b.Active == true)
          .Join(_applicationDbContext.Bookings,
                bill => bill.BillEntityId,
                booking => booking.BillEntityId,
                (bill, booking) => new { Bill = bill, Booking = booking })
          .Join(_applicationDbContext.RoomEntities,
                bb => bb.Booking.RoomEntityId,
                room => room.RoomEntityId,
                (bb, room) => new
                {
                    HotelName = room.HotelEntity.HotelName,
                    RoomNumber = room.RoomNum,
                    RoomBed = room.numOfBeds,
                      // BookingPrice = bb.Booking.Price ?? 0.0,
                      CheckInDate = bb.Booking.checkIn,
                    CheckOutDate = bb.Booking.checkOut,
                    bookId = bb.Booking.BookingEntityId,
                    roomId = bb.Booking.RoomEntityId
                })
          .ToList();
            try
            {

                 return Json(bookedRooms1);
               // return RedirectToAction("SearchHotels");
            }
            catch (DbUpdateException)
            {
                // Log the error or handle it accordingly
                return Json(new { success = false, message = "Error occurred while updating booking information." });
                //  return View("GetBookingsForCustomer");
            }
            //string l = "";
            //   var bok = bookedRooms;
            // return PartialView("_BookedRoomsPartial", bookedRooms);
            // return Json(bookedRooms);
        }
        public IActionResult CancelBooking(int bookId)
        {
            var res = _applicationDbContext.Bookings.Where(s => s.BookingEntityId == bookId).FirstOrDefault();
            if (res != null)
            {
                _applicationDbContext.Remove(res);
                _applicationDbContext.SaveChanges();
            }
            _toastNotification.AddSuccessToastMessage("Canceled room successfully.. ");
            return RedirectToAction("SearchHotel");
        }
        public async Task<IActionResult> BookingFinisedAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var customerId = _applicationDbContext.Customers
                .Where(n => n.UserEntityId == user.Id)
                .Select(n => n.CustomerEntityId)
                .FirstOrDefault();
            var isBookingActive = _applicationDbContext.Bills
           .Where(s => s.CustomerEntityId == customerId && s.Active == true)
           .Any();

            if (isBookingActive)
            {
                var booking = _applicationDbContext.Bills
                    .Where(d => d.CustomerEntityId == customerId && d.Active == true)
                    .FirstOrDefault();

                booking.Active = false;
                booking.Date = DateTime.Now;
                _applicationDbContext.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Booked room successfully.. ");
                //       return Json(new { success = true, message = "Booking information updated successfully." });
                return RedirectToAction("SearchHotel");
            }
            else
            {
                return Json(new { success = false, message = "No active booking found." });
            }
        }
        public IActionResult GetRoomProfile(int roomId)
        {

            var res = _applicationDbContext.RoomEntities
                    .Where(room => room.RoomEntityId == roomId)
                   .Select(room => new RoomDetailsDto
                   {
                       NumOfBeds = room.numOfBeds,
                       RoomNum = room.RoomNum,
                       Sea = room.sea,
                       Price = room.Price,
                       Suite = room.suite,
                       height = room.RoomSizeH,
                       width = room.RoomSizeW,
                       D1 = room.RoomDirection1,
                       D2 = room.RoomDirection2,
                       pric2 = room.Price2,
                       floor=room.floor,
                       phone=room.phone,
                       RoomEntityId=room.RoomEntityId,
                       RoomImagesUrls = room.Images.Select(image => new RoomImageDto
                       {
                           Id = image.Id,
                           Url = image.Url,
                           RoomEntityId = image.RoomEntityId
                       }).ToList(),
                       AvgRating = _applicationDbContext.Bookings
                   .Where(booking => booking.RoomEntityId == room.RoomEntityId && booking.Rate.HasValue)
                   .Average(booking => booking.Rate),
                       NumOfReviews = _applicationDbContext.Bookings
                   .Count(booking => booking.RoomEntityId == room.RoomEntityId && !string.IsNullOrEmpty(booking.Reviews)),
                       Hotel = new HotelDetailsDto
                       {
                           HotelName = room.HotelEntity.HotelName,
                           HotelAddress = room.HotelEntity.HotelAddress,
                           City = (OurHotels.Dto.Hotel.City)room.HotelEntity.City,
                           HotelDesccription = room.HotelEntity.Description,
                           NumOfStars = room.HotelEntity.numOfStars,
                           HotelPicture = room.HotelEntity.HotelPicture,
                       }
                   })
           .FirstOrDefault();

            ViewData["Reviews"] = _applicationDbContext.Bookings.Where(b => b.RoomEntityId == roomId).Select(s => s.Reviews).ToList();
            var servicesForRoomHotel = _applicationDbContext.Hotel_Extras
                 .Where(service => service.HotelEntity.RoomEntities.Any(room => room.RoomEntityId == roomId)).Where(s => s.Price >= 1).Select(s => new HotelServicesDto
                 {
                     Extra_ServicesName = s.Extra_ServicesName,
                     Price = s.Price,
                     Description = s.Description,
                     Extra_ServicesPicture = s.Extra_ServicesPicture
                 })
    .ToList();

            ViewData["Services"] = servicesForRoomHotel;
            ViewData["FreeServices"] = _applicationDbContext.Hotel_Extras.Where(service => service.HotelEntity.RoomEntities.Any(room => room.RoomEntityId == roomId)).Where(s => s.Price == 0).Select(s => s.Extra_ServicesName).ToList();

            return View("RoomProfile", res);
        }
        public async Task<IActionResult> AddServicesforbookingAsync(int roomId, List<double> servicesPrices, DateTime CheckinDate,DateTime CheckoutDate)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var customerId = _applicationDbContext.Customers
                .Where(n => n.UserEntityId == user.Id)
                .Select(n => n.CustomerEntityId)
                .FirstOrDefault();

            var IsNotAvailable = _applicationDbContext.Bookings
                .Any(booking =>
                        booking.RoomEntityId == roomId &&
                        (
            
                        (booking.checkIn <= CheckinDate && booking.checkOut >= CheckinDate) // the orange case
                            || (booking.checkIn <= CheckoutDate && booking.checkOut >= CheckoutDate) // the red case (and the yellow case)
                            || (booking.checkIn >= CheckinDate && booking.checkOut <= CheckoutDate) // the white case (and the yellow case)
                        )
                        &&
                        (
                            booking.BillEntity.Active == false || (booking.BillEntity.Active == true && booking.BillEntity.CustomerEntityId == customerId)
                        )
                    );

            if (IsNotAvailable)
            {

                return RedirectToAction("BookingConflict", "Error");
            }

            var roomprice = _applicationDbContext.RoomEntities.Where(r => r.RoomEntityId == roomId).Select(r=>r.Price).FirstOrDefault();

            foreach(var item in servicesPrices)
            {
                roomprice = roomprice + item;
            }

           var res= _applicationDbContext.Bookings.Where(b => b.RoomEntityId == roomId && b.checkIn == CheckinDate && b.checkOut == CheckoutDate).FirstOrDefault();
            res.Price = roomprice;
            
            return View("SearchHotel");
        }
        public IActionResult CancelFromCustomer(int id)
        {
          var res=  _applicationDbContext.Bookings.Where(b => b.BookingEntityId == id).FirstOrDefault();
            if(res!=null)
            {
                _applicationDbContext.Remove(res);
                _applicationDbContext.SaveChanges();
            }
            
            //_toastNotification.AddSuccessToastMessage("Booking canceled successfully.. ");
            return RedirectToAction("GetBookingsForCustomer");
        }
        public async Task<IActionResult> EditCustomerProfileSettingAsync(CustomerDto editDto)
        {
            var x = await _userManager.GetUserAsync(HttpContext.User);
            ViewData["Email"] = await _userManager.GetEmailAsync(x);
            var CustomerId = _applicationDbContext.Customers.Where(n => n.UserEntityId == x.Id)
                        .Select(n => n.CustomerEntityId).FirstOrDefault();
            //Program.HotelIdentity =
            //      _context.Customers.Where(u => u.UserEntityId == x.Id)
            //      .Select(u => u.IdentityCertifcate).FirstOrDefault();
            ViewData["CustomerProfileSetting"] = _Icustomer.GetCustomerById(CustomerId);
            if (ModelState.IsValid)
            {
                _Icustomer.EditeCustomer(CustomerId, editDto);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View("CustomerProfileSetting");
            }

        }

    }

    }

            
        
    
