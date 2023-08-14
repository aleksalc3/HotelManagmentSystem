using HotelManagment.Persistence.DatabaseContext;
using HotelManagmnet.Domain;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HotelManagmentSystem.Persistence.Tests
{
    public class HotelDatabaseContextTests
    {
        private HotelDatabaseContext _hotelDatabaseContext;

        public HotelDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HotelDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _hotelDatabaseContext = new HotelDatabaseContext(dbOptions);
        }
        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            //Arrange
            var booking = new Booking
            {
                Id = 1,        
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),

            };

            //Act

            await _hotelDatabaseContext.Bookings.AddAsync(booking);
            await _hotelDatabaseContext.SaveChangesAsync();

            //Assert
            booking.DateCreated.ShouldNotBeNull();
        }
        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            //Arrange
            var booking = new Booking
            {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),

            };

            //Act

            await _hotelDatabaseContext.Bookings.AddAsync(booking);
            await _hotelDatabaseContext.SaveChangesAsync();

            //Assert
            booking.DateModified.ShouldNotBeNull();
        }
    }
}