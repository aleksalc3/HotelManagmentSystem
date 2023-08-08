using AutoMapper;
using HotelManagementSystem.Application.Contracts.Logging;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using HotelManagementSystem.Application.Features.Room.Commands.UpdateRoom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Commands.CreateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IAppLogger<UpdateRoomCommandHandler> _logger;
        public UpdateRoomCommandHandler(IMapper mapper, IRoomRepository roomRepository, IAppLogger<UpdateRoomCommandHandler> logger)
        {
            this._mapper = mapper;
            this._roomRepository = roomRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            
            var validator = new UpdateRoomCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Validation errors in update request for {0} - {1}",nameof(Room),request.Id);
                throw new BadRequestException("Invalid Room", validationResult);
            }
            var room = await _roomRepository.GetById(request.Id);

            if (room == null)
                throw new NotFoundException(nameof(Room),request.Id);
            
             _mapper.Map(request,room);
            
            await _roomRepository.UpdateAsync(room);
            
            return Unit.Value;
        }
    }
}
