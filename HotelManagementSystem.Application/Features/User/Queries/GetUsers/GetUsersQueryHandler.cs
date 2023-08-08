using AutoMapper;
using HotelManagementSystem.Application.Contracts.Logging;
using HotelManagementSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.User.Queries.GetAllUsers
{
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAppLogger<GetUserQueryHandler> _logger;

        public GetUserQueryHandler(IMapper mapper, IUserRepository userRepository, IAppLogger<GetUserQueryHandler> logger)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
            this._logger = logger;
        }
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var UserTypes = await _userRepository.GetAsync();
            //convert data objects to DTO objects
            var data = _mapper.Map<List<UserDto>>(UserTypes);
            //return list of DTO object
            _logger.LogInformation("Users were retrieved successfully!");
            return data;
        }
    }
}
