using FluentValidation;
using HotelManagementSystem.Application.Features.User.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.User.Commands.UpdateUser
{
    internal class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
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
