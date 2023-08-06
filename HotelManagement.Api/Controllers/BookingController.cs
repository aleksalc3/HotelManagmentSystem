using HotelManagementSystem.Application.Features.Booking.Commands.CreateBooking;
using HotelManagementSystem.Application.Features.Booking.Queries.GetAllBookings;
using HotelManagementSystem.Application.Features.Booking.Queries.GetBookingDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public async Task<List<BookingsDto>> Get()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQuery());
            return bookings;
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<BookingDetailsDto> Get(int id)
        {
            var booking = await _mediator.Send(new GetBookingDetailsQuery(id));
            return booking;
        }

        // POST api/<BookingController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Post(CreateBookingCommand booking)
        {
            var response = await _mediator.Send(booking);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateBookingCommand booking)
        {
            await _mediator.Send(booking);
            return NoContent();
        }
        
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int bookingId)
        {
            var command = new DeleteBookingCommand() { Id = bookingId }; ;
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
