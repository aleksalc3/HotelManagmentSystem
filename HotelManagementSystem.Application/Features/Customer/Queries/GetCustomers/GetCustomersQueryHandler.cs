using AutoMapper;
using HotelManagementSystem.Application.Contracts.Logging;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Customer.Queries.GetAllBookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAppLogger<GetAllCustomerQueryHandler> _logger;

        public GetAllCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository, IAppLogger<GetAllCustomerQueryHandler> logger)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
            this._logger = logger;
        }
        public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var customerTypes = await _customerRepository.GetAsync();
            //convert data objects to DTO objects
            var data = _mapper.Map<List<CustomerDto>>(customerTypes);
            //return list of DTO object
            _logger.LogInformation("customers were retrieved successfully!");
            return data;
        }
    }
}
