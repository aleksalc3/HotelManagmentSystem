using FluentValidation;
using HotelManagementSystem.Application.Features.Customer.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Customer.Commands.UpdateCustomer
{
    internal class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
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
