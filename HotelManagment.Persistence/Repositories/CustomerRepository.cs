using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagment.Persistence.DatabaseContext;
using HotelManagmnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelDatabaseContext context) : base(context)
        {

        }

        public async Task<List<Booking>> GetCustomerBookings(int customerId)
        {
            return await _context.Bookings.Where(r => r.CustomerId == customerId).ToListAsync();
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task UpdateCustomerAddress(int customerId, string newAddress)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                customer.Address = newAddress;
                await _context.SaveChangesAsync();
            }
        }
    }
}
