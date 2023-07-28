using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator()
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
