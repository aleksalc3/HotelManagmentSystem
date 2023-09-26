using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagment.Persistence.DatabaseContext;
using HotelManagmnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Persistence.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelDatabaseContext context) : base(context)
        {

        }
        //First Version
        public async Task<List<Room>> GetAvailableRoomsByBookings(DateTime checkInDate, DateTime checkOutDate)
        {
            var reserverRoomsIds= _context.Bookings
                .Where(q=>q.StartDate< checkOutDate && q.EndDate>checkInDate)
                .Select(q=>q.RoomId)
                .ToList();
            return await _context.Rooms.Where(q=>q.IsAvailable && !reserverRoomsIds.Contains(q.Id)).ToListAsync();
        }
        //Second Version
        public async Task<List<Room>> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            var availableRooms = await _context.Rooms
                .Where(r => r.IsAvailable).ToListAsync();
            return availableRooms;
        }
        public async Task<int> GetRoomCapacity(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            return room?.Capacity ?? 0;
        }

        public async Task<List<Room>> GetRoomsByType(string type)
        {
            return await _context.Rooms.Where(q => q.RoomType == type && q.IsAvailable).ToListAsync();
        }

        public async Task MarkRoomAsAvailable(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room != null)
            {
                room.IsAvailable = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkRoomAsOccupied(int roomId)
        {
            var room =await _context.Rooms.FindAsync(roomId);
            if (room != null) 
            {
                room.IsAvailable = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
