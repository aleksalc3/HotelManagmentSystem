using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagmnet.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Booking.Queries.GetBookingDetails
{
    internal class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerDetailsQueryHandler(IMapper mapper, ICustomerRepository _customerRepository)
        {
            this._mapper = mapper;
            this._customerRepository = _customerRepository;
        }

        public async Task<CustomerDetailsDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            //calls default method for getting Booking object 
            var customer = await _customerRepository.GetById(request.Id);

            //convert data objects to DTO objects
            //Verify that record exist
            if (customer == null) throw new NotFoundException(nameof(Customer), request.Id);
            var data = _mapper.Map<HotelManagmnet.Domain.Customer, CustomerDetailsDto>(customer);
            //return list of DTO object
            return data;
        }
    }
}
