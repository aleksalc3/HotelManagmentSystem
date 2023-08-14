using AutoMapper;
using HotelManagementSystem.Application.Contracts.Logging;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagementSystem.Application.MappingProfiles;
using HotelManagementSystem.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.UnitTests.Features.Bookings.Queries
{
    public class GetBookingListQueryHandlerTests
    {
        private readonly Mock<IBookingRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetAllBookingQueryHandler>> _mockAppLogger;

        public GetBookingListQueryHandlerTests()
        {
            _mockRepo = MockBookingRepository.GetMockBookingsRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BookingProfile>();
                c.AddProfile<CustomerProfile>();
                c.AddProfile<RoomProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetAllBookingQueryHandler>>();
        }

        [Fact]
        public async Task GetBookingsTest()
        {
            var handler = new GetAllBookingQueryHandler(_mapper,
                _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetAllBookingsQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<BookingsDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
