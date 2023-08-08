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

namespace HotelManagementSystem.Application.Features.User.Queries.GetUserDetails
{
    internal class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserDetailsQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            //calls default method for getting User object 
            var userType = await _userRepository.GetById(request.Id);

            //convert data objects to DTO objects
            //Verify that record exist
            if (userType == null) throw new NotFoundException(nameof(User), request.Id);
            var data = _mapper.Map<HotelManagmnet.Domain.User, UserDetailsDto>(userType);
            //return list of DTO object
            return data;
        }
    }
}
