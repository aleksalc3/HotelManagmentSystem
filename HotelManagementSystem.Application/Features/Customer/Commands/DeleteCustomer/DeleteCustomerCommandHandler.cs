using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.Customer.Commands.CreateCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Customer.Commands.Createcustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)=>this._customerRepository = customerRepository;
        
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            //Retrieve domain entity object
            var customerToDelete = await _customerRepository.GetById(request.Id);
            //Verify that record exist
            if (customerToDelete == null) throw new NotFoundException(nameof(Customer), request.Id);
            //Remove from database
            await _customerRepository.DeleteAsync(customerToDelete);
            //return record id
            return Unit.Value;
        }
    }
}
