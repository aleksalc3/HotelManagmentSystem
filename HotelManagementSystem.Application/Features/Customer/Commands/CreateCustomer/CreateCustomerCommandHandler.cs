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

namespace HotelManagementSystem.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
        }
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            //Validate incomnig data
            var validator = new CreateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (!validationResult.IsValid) throw new BadRequestException("Invalid Customer", validationResult);
            //Convert to domain entity object
            var customerToCreate = _mapper.Map<CreateCustomerCommand,HotelManagmnet.Domain.Customer>(request);
            //Add to database
            await _customerRepository.CreateAsync(customerToCreate);
            //return record id
            return customerToCreate.Id;
        }
    }
}
