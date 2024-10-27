using MediatR;
using PartyMix.Application.Security;
using PartyMix.Contracts;
using PartyMix.Persistence;

namespace PartyMix.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomVm>
{
    private readonly PartyMixDbContext _dbContext;

    public CreateRoomCommandHandler(PartyMixDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RoomVm> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = request.ToRoom();
        room.PasswordHash = SecretHasher.Hash(request.Password);

        _dbContext.Rooms.Add(room);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return room.ToVm();
    }
}