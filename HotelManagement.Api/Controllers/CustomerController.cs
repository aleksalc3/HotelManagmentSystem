using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Booking.Queries.GetBookingDetails;
using HotelManagementSystem.Application.Features.Customer.Commands.CreateCustomer;
using HotelManagementSystem.Application.Features.Customer.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Customer.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<CustomerDto>> Get()
        {
            var customers = await _mediator.Send(new GetCustomersQuery());
            return customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<CustomerDetailsDto> Get(int id)
        {
            var customer = await _mediator.Send(new GetCustomerDetailsQuery(id));
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Post(CreateCustomerCommand Customer)
        {
            var response = await _mediator.Send(Customer);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCustomerCommand Customer)
        {
            await _mediator.Send(Customer);
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand() { Id = id }; ;
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
