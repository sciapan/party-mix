using MediatR;
using PartyMix.Application.Rooms.Models;

namespace PartyMix.Application.Rooms.Commands;

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