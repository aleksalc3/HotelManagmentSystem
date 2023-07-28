using FluentValidation;
using HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Commands.UpdateBooking
{
    internal class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommand>
    {
        public UpdateBookingCommandValidator()
        {
            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{StartDate} is required")
                .NotNull();

            RuleFor(p => p.EndDate)
                .NotEmpty().WithMessage("{EndDate} is required")
                .NotNull();

        }
    }
}
