using MediatR;
using OneOf;
using OneOf.Types;

namespace PartyMix.Application.Rooms.Commands.EnterRoom
{
    /// <summary>
    /// Command to enter room.
    /// </summary>
    public class EnterRoomCommand : IRequest<OneOf<Success, NotFound, Error>>
    {
        /// <summary>
        /// Room id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Room password.
        /// </summary>
        public string Password { get; set; }
    }
}