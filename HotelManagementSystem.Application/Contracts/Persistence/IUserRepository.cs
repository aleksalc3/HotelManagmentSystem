using HotelManagmnet.Domain;

namespace HotelManagementSystem.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsername(string username);
        Task<List<User>> GetUsersByRole(string role);
        Task UpdateUserPassword(int userId, string newPassword);
    }
}
