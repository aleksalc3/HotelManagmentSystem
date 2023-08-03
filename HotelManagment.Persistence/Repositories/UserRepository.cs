using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagment.Persistence.DatabaseContext;
using HotelManagmnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HotelDatabaseContext context) : base(context)
        {

        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<User>> GetUsersByRole(string role)
        {
            return await _context.Users.Where(u => u.Role == role).ToListAsync();
        }

        public async Task UpdateUserPassword(int userId, string newPassword)
        {
            var user =await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.Password = newPassword;
                await _context.SaveChangesAsync();
            }
        }
    }
}
