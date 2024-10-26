using MediatR;
using OneOf;
using OneOf.Types;
using PartyMix.Application.Security;
using PartyMix.Persistence;

namespace PartyMix.Application.Rooms.Commands.EnterRoom
{
    public class EnterRoomCommandHandler : IRequestHandler<EnterRoomCommand, OneOf<Success, NotFound, Error>>
    {
        private readonly PartyMixDbContext _dbContext;

        public EnterRoomCommandHandler(PartyMixDbContext context)
        {
            _dbContext = context;
        }

        public async Task<OneOf<Success, NotFound, Error>> Handle(EnterRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _dbContext.Rooms.FindAsync(Ulid.Parse(request.Id), cancellationToken);
            if (room == null)
            {
                // room not found
                return new NotFound();
            }

            // validate password
            if (!SecretHasher.Verify(request.Password, room.PasswordHash))
            {
                // password is incorrect
                return new Error();
            }
            
            // TODO enter signalR hub
            return new Success();
        }
    }
}