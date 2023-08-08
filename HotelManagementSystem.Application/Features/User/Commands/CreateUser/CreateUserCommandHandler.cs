using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.User.Queries.GetAllUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Validate incomnig data
            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (!validationResult.IsValid) throw new BadRequestException("Invalid User", validationResult);
            //Convert to domain entity object
            var userToCreate = _mapper.Map<CreateUserCommand,HotelManagmnet.Domain.User>(request);
            //Add to database
            await _userRepository.CreateAsync(userToCreate);
            //return record id
            return userToCreate.Id;
        }
    }
}
