using OurHotels.Dto;
using OurHotels.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurHotel.IRepo
{
    public interface ICustomerRepo
    {
        public void AddCustomer(AddCustomerDto addDto , string userId);
        public void UpdateCustomer(UpdateCustomerDto Updatedto);
        public void DeleteCustomer(int id);
        public CustomerDto GetCustomerById(int id);
        public int GetCustomersCount();
        public List<CustomerDto> GetAllCustomer();
        public  Task<List<BookingInfoDto>> GetBookingsForCustomer(int customerId);
        public  Task<List<BookingInfoDto>> GetBookingsForCustomerByDate(int customerId, DateTime? from, DateTime? to);
        public List<BookingResult> GetAllCustomers();
        public void EditeCustomer(int customerId, CustomerDto Updatedto);

    }
}
