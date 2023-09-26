using AutoMapper;
using HotelManagementSystem.Application.Contracts.Logging;
using HotelManagementSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings
{
    public class GetBookingWithinDateRangeQueryHandler : IRequestHandler<GetBookingsWithinDataRangeQuery, List<BookingsWithinDateRangeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly IAppLogger<GetBookingWithinDateRangeQueryHandler> _logger;

        public GetBookingWithinDateRangeQueryHandler(IMapper mapper, IBookingRepository bookingRepository, IAppLogger<GetBookingWithinDateRangeQueryHandler> logger)
        {
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
            this._logger = logger;
        }
        public async Task<List<BookingsWithinDateRangeDto>> Handle(GetBookingsWithinDataRangeQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var bookings = await _bookingRepository.GetBookingsWithinDateRange(request.startTime, request.endDate);
            //convert data objects to DTO objects
            var data = _mapper.Map<List<BookingsWithinDateRangeDto>>(bookings);
            //return list of DTO object
            _logger.LogInformation("Bookings were retrieved successfully!");
            return data;
        }

        
    }
}
