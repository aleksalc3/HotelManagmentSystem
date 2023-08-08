using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.Room.Queries.GetAllRooms;
using MediatR;


namespace HotelManagementSystem.Application.Features.Room.Queries.GetRoomDetails
{
    internal class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public GetRoomDetailsQueryHandler(IMapper mapper, IRoomRepository roomRepository)
        {
            this._mapper = mapper;
            this._roomRepository = roomRepository;
        }

        public async Task<RoomDetailsDto> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            //calls default method for getting Room object 
            var roomType = await _roomRepository.GetById(request.Id);

            //convert data objects to DTO objects
            //Verify that record exist
            if (roomType == null) throw new NotFoundException(nameof(Room), request.Id);
            var data = _mapper.Map<HotelManagmnet.Domain.Room, RoomDetailsDto>(roomType);
            //return list of DTO object
            return data;
        }
    }
}
