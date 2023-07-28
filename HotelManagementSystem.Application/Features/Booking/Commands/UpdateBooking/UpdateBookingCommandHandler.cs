using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.Booking.Commands.UpdateBooking;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        public UpdateBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
        }
        public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            //Validate incomnig data
            var validator = new UpdateBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid) throw new BadRequestException("Invalid Booking", validationResult);
            //Convert to domain entity object
            var bookingToUpdate = _mapper.Map<HotelManagmnet.Domain.Booking>(request);
            //Add to database
            await _bookingRepository.UpdateAsync(bookingToUpdate);
            //return record id
            return Unit.Value;
        }
    }
}
