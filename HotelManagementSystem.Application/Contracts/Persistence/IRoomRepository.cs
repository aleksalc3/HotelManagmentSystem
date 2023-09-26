using HotelManagmnet.Domain;

namespace HotelManagementSystem.Application.Contracts.Persistence
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task MarkRoomAsOccupied(int roomId);

        Task MarkRoomAsAvailable(int roomId);
        Task<List<Room>> GetRoomsByType(string type);
        Task<List<Room>> GetAvailableRoomsByBookings(DateTime checkInDate, DateTime checkOutDate);
        Task<List<Room>> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate);
        Task<int> GetRoomCapacity(int roomId);

    }
}
