using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagmnet.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.UnitTests.Mocks
{
    public class MockBookingRepository
    {
        public static Mock<IBookingRepository> GetMockBookingsRepository() 
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id=1,
                    Address="Vojvode Stepe 204",
                    Email="test@gmail.com",
                    Name="Aleksa",
                    Phone="0695141297"
                },
                new Customer
                {
                    Id=2,
                    Address="Cvijiceva 7/22",
                    Email="test222@gmail.com",
                    Name="Igor",
                    Phone="0612312323"
                }
            };
            var rooms = new List<Room>
            {
                new Room
                {
                    Id=1,
                    Capacity=2,
                    IsAvailable=true,
                    RoomNumber=001,
                    RoomType="apartment"
                },
                new Room
                {
                    Id=2,
                    Capacity=3,
                    IsAvailable=false,
                    RoomNumber=004,
                    RoomType="exclusive"
                }
            };
            var bookings = new List<Booking>
            {
                new Booking
                {
                    Id=1,
                    Customer=customers[0],
                    CustomerId=customers[0].Id,
                    Room=rooms[0],
                    RoomId=rooms[0].Id,
                    StartDate=DateTime.Now,
                    EndDate=DateTime.Now.AddDays(5),

                },
                new Booking
                {
                    Id=2,
                    Customer=customers[1],
                    CustomerId=customers[1].Id,
                    Room=rooms[1],
                    RoomId=rooms[1].Id,
                    StartDate=DateTime.Now.AddDays(2),
                    EndDate=DateTime.Now.AddDays(6),

                }
            };
            var mockRepo = new Mock<IBookingRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(bookings);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Booking>()))
                .Returns((Booking booking) =>
                {
                    bookings.Add(booking);
                    return Task.CompletedTask;
                });
            return mockRepo;
        }
    }
}
