using AutoMapper;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Customer.Commands.CreateCustomer;
using HotelManagementSystem.Application.Features.Customer.Queries.GetAllBookings;
using HotelManagmnet.Domain;

namespace HotelManagementSystem.Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<Customer, CustomerDetailsDto>();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();

        }
    }
}
