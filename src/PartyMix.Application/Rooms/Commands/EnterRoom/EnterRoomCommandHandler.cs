using MediatR;
using PartyMix.Application.Security;
using PartyMix.Persistence;

namespace PartyMix.Application.Rooms.Commands.EnterRoom
{
    public class EnterRoomCommandHandler : IRequestHandler<EnterRoomCommand>
    {
        private readonly PartyMixDbContext _context;

        public EnterRoomCommandHandler(PartyMixDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EnterRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.FindAsync(request.Id);
            if (room == null)
            {
                // room not found
                return;
            }

            // validate password
            if (!SecretHasher.Verify(request.Password, room.PasswordHash))
            {
                // password is incorrect
                return;
            }

            // enter signalR hub
        }
    }
}
