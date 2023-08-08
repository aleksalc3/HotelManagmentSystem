using AutoMapper;
using HotelManagementSystem.Application.Contracts.Logging;
using HotelManagementSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms
{
    public class GetAllRoomQueryHandler : IRequestHandler<GetAllRoomsQuery, List<RoomDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IAppLogger<GetAllRoomQueryHandler> _logger;

        public GetAllRoomQueryHandler(IMapper mapper, IRoomRepository roomRepository, IAppLogger<GetAllRoomQueryHandler> logger)
        {
            this._mapper = mapper;
            this._roomRepository = roomRepository;
            this._logger = logger;
        }
        public async Task<List<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var roomTypes = await _roomRepository.GetAsync();
            //convert data objects to DTO objects
            var data = _mapper.Map<List<RoomDto>>(roomTypes);
            //return list of DTO object
            _logger.LogInformation("Rooms were retrieved successfully!");
            return data;
        }
    }
}
