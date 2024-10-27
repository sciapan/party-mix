using MediatR;
using PartyMix.Contracts;

namespace PartyMix.Application.Rooms.Commands.CreateRoom;

/// <summary>
/// Command to create a new room.
/// </summary>
public class CreateRoomCommand : IRequest<RoomVm>
{
    /// <summary>
    /// The name of the room.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The password of the room.
    /// </summary>
    public string Password { get; set; }
}