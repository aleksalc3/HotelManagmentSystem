using HotelManagementSystem.Application.Features.Room.Commands.CreateRoom;
using HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms;
using HotelManagementSystem.Application.Features.Room.Queries.GetRoomDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<RoomController>
        [HttpGet]
        public async Task<List<RoomDto>> Get()
        {
            var rooms = await _mediator.Send(new GetAllRoomsQuery());
            return rooms;
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public async Task<RoomDetailsDto> Get(int id)
        {
            var room = await _mediator.Send(new GetRoomDetailsQuery(id));
            return room;
        }

        // POST api/<RoomController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Post(CreateRoomCommand Room)
        {
            var response = await _mediator.Send(Room);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateRoomCommand Room)
        {
            await _mediator.Send(Room);
            return NoContent();
        }
        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]        
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteRoomCommand() { Id = id }; ;
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
