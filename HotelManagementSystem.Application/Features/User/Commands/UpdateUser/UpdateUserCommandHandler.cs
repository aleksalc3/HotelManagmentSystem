using AutoMapper;
using HotelManagementSystem.Application.Contracts.Logging;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.User.Commands.UpdateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.User.Commands.CreateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAppLogger<UpdateUserCommandHandler> _logger;
        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IAppLogger<UpdateUserCommandHandler> logger)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //Validate incomnig data
            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Validation errors in update request for {0} - {1}",nameof(User),request.Id);
                throw new BadRequestException("Invalid User", validationResult);
            } 
            //Convert to domain entity object
            var userToUpdate = _mapper.Map<UpdateUserCommand, HotelManagmnet.Domain.User>(request);
            //Add to database
            await _userRepository.UpdateAsync(userToUpdate);
            //return record id
            return Unit.Value;
        }
    }
}
