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
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, Unit>
    {
        private readonly IBookingRepository _bookingRepository;
        public DeleteBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository)=>this._bookingRepository = bookingRepository;
        
        public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {

            //Retrieve domain entity object
            var bookingToDelete = await _bookingRepository.GetById(request.Id);
            //Verify that record exist
            if (bookingToDelete == null) throw new NotFoundException(nameof(Booking), request.Id);
            //Remove from database
            await _bookingRepository.DeleteAsync(bookingToDelete);
            //return record id
            return Unit.Value;
        }
    }
}
