using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using MediatR;

namespace HotelManagementSystem.Application.Features.Room.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        public CreateRoomCommandHandler(IMapper mapper, IRoomRepository roomRepository)
        {
            this._mapper = mapper;
            this._roomRepository = roomRepository;
        }
        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            //Validate incomnig data
            var validator = new CreateRoomCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (!validationResult.IsValid) throw new BadRequestException("Invalid Room", validationResult);
            //Convert to domain entity object
            var roomToCreate = _mapper.Map<CreateRoomCommand,HotelManagmnet.Domain.Room>(request);
            //Add to database
            await _roomRepository.CreateAsync(roomToCreate);
            //return record id
            return roomToCreate.Id;
        }
    }
}
