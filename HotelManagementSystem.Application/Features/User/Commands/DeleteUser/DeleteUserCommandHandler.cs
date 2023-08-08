using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.User.Commands.CreateUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IMapper mapper, IUserRepository userRepository)=>this._userRepository = userRepository;
        
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            //Retrieve domain entity object
            var UserToDelete = await _userRepository.GetById(request.Id);
            //Verify that record exist
            if (UserToDelete == null) throw new NotFoundException(nameof(User), request.Id);
            //Remove from database
            await _userRepository.DeleteAsync(UserToDelete);
            //return record id
            return Unit.Value;
        }
    }
}
