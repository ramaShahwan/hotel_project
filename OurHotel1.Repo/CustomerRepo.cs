using AutoMapper;
using Microsoft.EntityFrameworkCore;
using My_Tables.Entities;
using MyDbProject;
using OurHotel.IRepo;
using OurHotels.Dto;
using OurHotels.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.Repo
{
   public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerRepo(ApplicationDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public void AddCustomer(AddCustomerDto addDto , string userId)
        {

            addDto.UserEntityId = userId;
            var result = _mapper.Map<CustomerEntity>(addDto);
            _context.Customers.Add(result);
            _context.SaveChanges();

        }

        public void UpdateCustomer(UpdateCustomerDto Updatedto)
        {
            var res = _mapper.Map<CustomerEntity>(Updatedto);
            _context.Customers.Update(res);
            _context.SaveChanges();

        }

        public void DeleteCustomer(int id)
        {
            var result = _context.Customers.FirstOrDefault(x => x.CustomerEntityId == id);
            if (result != null)
            {
                _context.Customers.Remove(result);
                _context.SaveChanges();
            }
            else
            {
                // throw new NotFoundException();
            }


        }

        public CustomerDto GetCustomerById(int id)
        {
            var res = _context.Customers.FirstOrDefault(x => x.CustomerEntityId == id);
            if (res == null)
            {

                return null;
            }
            else
            {
                var result = _mapper.Map<CustomerDto>(res);
                return result;
            }
        }

        public int GetCustomersCount()
        {
            return _context.Customers.Count();
        }
        public List<CustomerDto> GetAllCustomer()
        {
            //// Create a source object

            //var source = new CustomerEntity() {
            //    FirstName =,
            //    LastName = ,

            //};

            //// Map the source object to a destination object
            //var destination = _mapper.Map<CustomerDto>(source);

            //// Use the mapped destination object
            //// ...

            //return destination;


            List<CustomerDto> customrers = new List<CustomerDto>();
            var result = _context.Customers.ToList();
            foreach (var item in result)
            {
                customrers.Add(_mapper.Map<CustomerDto>(item));
            }
            return customrers;
        }
        public async Task<List<BookingInfoDto>> GetBookingsForCustomer(int customerId)
        {


            var bookings = await _context.Bookings
           .Include(booking => booking.RoomEntity)
           .ThenInclude(room => room.HotelEntity)
           .Where(booking => booking.BillEntity.CustomerEntityId == customerId)
           .Where(bookings => bookings.BillEntity.Active == false)
                .Select(booking => new BookingInfoDto
                {
                    HotelName = booking.RoomEntity.HotelEntity.HotelName,
                    HotelImage = booking.RoomEntity.HotelEntity.HotelPicture,
                    CheckInDate = booking.checkIn,
                    CheckOutDate = booking.checkOut,
                    BookingDate = booking.BookingDate,
                    Price = booking.Price,
                    Rating=booking.Rate,
                    Review=booking.Reviews,
                    BookingId=booking.BookingEntityId,
                    Roomnum= booking.RoomEntity.RoomNum,
                    City = (OurHotels.Dto.Hotel.City)booking.RoomEntity.HotelEntity.City
                })
                .OrderByDescending(b=>b.BookingId)
                .ToListAsync();

            return bookings;
        }

        public async Task<List<BookingInfoDto>> GetBookingsForCustomerByDate(int customerId, DateTime? from, DateTime? to)
        {
            var bookings = await _context.Bookings
          .Include(booking => booking.RoomEntity)
          .ThenInclude(room => room.HotelEntity)
          .Where(booking => booking.BillEntity.CustomerEntityId == customerId)
          .Where(bookings => bookings.BillEntity.Active == false)
          .Where(bookings=>bookings.BillEntity.Date>= from && bookings.BillEntity.Date <=to)
               .Select(booking => new BookingInfoDto
               {
                   HotelName = booking.RoomEntity.HotelEntity.HotelName,
                   HotelImage = booking.RoomEntity.HotelEntity.HotelPicture,
                   CheckInDate = booking.checkIn,
                   CheckOutDate = booking.checkOut,
                   BookingDate = booking.BillEntity.Date,
                   Price = booking.Price,
                   Rating = booking.Rate,
                   Review = booking.Reviews,
                   BookingId = booking.BookingEntityId,
                   Roomnum = booking.RoomEntity.RoomNum,
                   City = (OurHotels.Dto.Hotel.City)booking.RoomEntity.HotelEntity.City
               })
               .ToListAsync();


            return bookings;
           // throw new NotImplementedException();
        }
        //from admin 
        public List<BookingResult> GetAllCustomers()
        {
            var result = _context.Customers
                .Include(c => c.BillEntities)
                .ThenInclude(b => b.BookingEntities)
                .ToList() // Fetch customers from the database
                .Select(c =>
                {
                    var bookingEntities = c.BillEntities?.SelectMany(b => b.BookingEntities).ToList();
                    var totalBillPaid = bookingEntities?.Sum(booking => booking.Price) ?? 0;
                    var latestBookingDate = bookingEntities?.OrderByDescending(booking => booking.BookingDate).FirstOrDefault()?.BookingDate ?? DateTime.MinValue;

                    return new BookingResult
                    {
                        CustomerEntityId = c.CustomerEntityId,
                        CustomerFirstName = c.FirstName,
                        CustomerLastName = c.LastName,
                        PhoneNumber = c.phoneNumber,
                        TotalBillPaid = totalBillPaid,
                        BookingDate = latestBookingDate
                    };
                })
                .OrderByDescending(b => b.BookingDate)
                .ToList();

            var bookingResults = _mapper.Map<List<BookingResult>>(result);
            return bookingResults;
        }
        public void EditeCustomer(int customerId, CustomerDto Updatedto)
        {
            var res = _context.Customers.FirstOrDefault(x => x.CustomerEntityId == customerId);
            if (res != null)
            {
               // res.gender = (My_Tables.Entities.Gender)Updatedto.gender;
                if (!string.IsNullOrEmpty(Updatedto.FirstName))
                {
                    res.FirstName = Updatedto.FirstName;
                }
                if (!string.IsNullOrEmpty(Updatedto.LastName))
                {
                    res.LastName = Updatedto.LastName;
                }
                if ((Updatedto.phoneNumber != 0))
                {
                    res.phoneNumber = Updatedto.phoneNumber;
                }
                if (Updatedto.Birthday != default(DateTime))
                {
                    res.Birthday = Updatedto.Birthday;
                }
            }
            _context.SaveChanges();
        }


    }
}

