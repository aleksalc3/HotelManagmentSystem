using HotelManagementSystem.Application.Features.User.Commands.CreateUser;
using HotelManagementSystem.Application.Features.User.Queries.GetAllUsers;
using HotelManagementSystem.Application.Features.User.Queries.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDetailsDto> Get(int id)
        {
            var user = await _mediator.Send(new GetUserDetailsQuery(id));
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Post(CreateUserCommand User)
        {
            var response = await _mediator.Send(User);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateUserCommand User)
        {
            await _mediator.Send(User);
            return NoContent();
        }
        
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand() { Id = id }; ;
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
