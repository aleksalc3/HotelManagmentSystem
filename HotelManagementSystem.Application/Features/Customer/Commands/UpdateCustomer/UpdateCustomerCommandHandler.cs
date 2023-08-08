using AutoMapper;
using HotelManagementSystem.Application.Contracts.Logging;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.Customer.Commands.UpdateCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Customer.Commands.CreateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAppLogger<UpdateCustomerCommandHandler> _logger;
        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository, IAppLogger<UpdateCustomerCommandHandler> logger)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            //Validate incomnig data
            var validator = new UpdateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Validation errors in update request for {0} - {1}",nameof(Customer),request.Id);
                throw new BadRequestException("Invalid Customer", validationResult);
            } 
            //Convert to domain entity object
            var CustomerToUpdate = _mapper.Map<UpdateCustomerCommand, HotelManagmnet.Domain.Customer>(request);
            //Add to database
            await _customerRepository.UpdateAsync(CustomerToUpdate);
            //return record id
            return Unit.Value;
        }
    }
}
