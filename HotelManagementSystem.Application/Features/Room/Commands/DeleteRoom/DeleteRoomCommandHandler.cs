using AutoMapper;
using HotelManagementSystem.Application.Contracts.Persistence;
using HotelManagementSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Application.Features.Room.Commands.CreateRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Unit>
    {
        private readonly IRoomRepository _roomRepository;
        public DeleteRoomCommandHandler(IMapper mapper, IRoomRepository RoomRepository)=>this._roomRepository = RoomRepository;
        
        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {

            //Retrieve domain entity object
            var roomToDelete = await _roomRepository.GetById(request.Id);
            //Verify that record exist
            if (roomToDelete == null) throw new NotFoundException(nameof(Room), request.Id);
            //Remove from database
            await _roomRepository.DeleteAsync(roomToDelete);
            //return record id
            return Unit.Value;
        }
    }
}
