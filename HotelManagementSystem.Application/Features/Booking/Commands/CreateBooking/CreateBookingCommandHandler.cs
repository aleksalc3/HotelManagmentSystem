using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        public CreateBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository)
        {
            this._mapper = mapper;
            this._bookingRepository = bookingRepository;
        }
        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            //Validate incomnig data
            var validator = new CreateBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid) throw new BadRequestException("Invalid Booking", validationResult);
            //Convert to domain entity object
            var bookingToCreate = _mapper.Map<HotelManagmnet.Domain.Booking>(request);
            //Add to database
            await _bookingRepository.CreateAsync(bookingToCreate);
            //return record id
            return bookingToCreate.Id;
        }
    }
}
