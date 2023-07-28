using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetBookingDetails
{
    internal class GetBookingDetailsQueryHandler : IRequestHandler<GetBookingDetailsQuery, BookingDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;

        public GetBookingDetailsQueryHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
        }

        public async Task<BookingDetailsDto> Handle(GetBookingDetailsQuery request, CancellationToken cancellationToken)
        {
            var bookingType = await _bookingRepository.GetById(request.Id);
            //convert data objects to DTO objects
            //Verify that record exist
            if (bookingType == null) throw new NotFoundException(nameof(Booking), request.Id);
            var data = _mapper.Map<BookingDetailsDto>(bookingType);
            //return list of DTO object
            return data;
        }
    }
}
