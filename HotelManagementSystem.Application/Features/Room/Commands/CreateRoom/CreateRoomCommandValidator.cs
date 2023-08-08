using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            //RuleFor(p => p.StartDate)
            //    .NotEmpty().WithMessage("{StartDate} is required")
            //    .NotNull();

            //RuleFor(p => p.EndDate)
            //    .NotEmpty().WithMessage("{EndDate} is required")
            //    .NotNull();

        }
    }
}
