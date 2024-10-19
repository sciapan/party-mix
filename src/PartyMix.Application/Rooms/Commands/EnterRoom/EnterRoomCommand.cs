using MediatR;

namespace PartyMix.Application.Rooms.Commands.EnterRoom
{
    /// <summary>
    /// Command to enter room.
    /// </summary>
    public class EnterRoomCommand : IRequest
    {
        /// <summary>
        /// Room id.
        /// </summary>
        public Ulid Id { get; set; }

        /// <summary>
        /// Room password.
        /// </summary>
        public string Password { get; set; }
    }
}