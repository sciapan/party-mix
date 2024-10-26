using MediatR;
using OneOf;
using OneOf.Types;
using PartyMix.Application.Rooms.Models;

namespace PartyMix.Application.Rooms.Queries.GetRoom;

/// <summary>
/// Query to get room by id.
/// </summary>
public class GetRoomQuery : IRequest<OneOf<RoomVm, NotFound>>
{
    /// <summary>
    /// Room id.
    /// </summary>
    public string Id { get; init; }
}