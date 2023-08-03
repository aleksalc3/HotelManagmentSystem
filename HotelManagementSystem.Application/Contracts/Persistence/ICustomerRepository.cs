using HotelManagmnet.Domain;

namespace HotelManagementSystem.Application.Contracts.Persistence
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<List<Booking>> GetCustomerBookings(int customerId);
        Task<Customer> GetCustomerByEmail(string email);
        Task UpdateCustomerAddress(int customerId, string newAddress);
    }
}
