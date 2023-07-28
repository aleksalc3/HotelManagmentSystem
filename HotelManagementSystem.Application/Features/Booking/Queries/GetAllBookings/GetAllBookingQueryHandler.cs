using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings
{
    public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingsQuery, List<BookingsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;

        public GetAllBookingQueryHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
        }
        public async Task<List<BookingsDto>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var bookingTypes = await _bookingRepository.GetAsync();
            //convert data objects to DTO objects
            var data = _mapper.Map<List<BookingsDto>>(bookingTypes);
            //return list of DTO object
            return data;
        }
    }
}
