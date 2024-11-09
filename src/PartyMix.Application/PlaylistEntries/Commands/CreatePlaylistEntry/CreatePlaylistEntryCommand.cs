using FluentValidation.Results;
using MediatR;
using OneOf;
using OneOf.Types;
using PartyMix.Contracts;

namespace PartyMix.Application.PlaylistEntries.Commands.CreatePlaylistEntry;

/// <summary>
/// Command to create playlist entry.
/// </summary>
public class CreatePlaylistEntryCommand : IRequest<OneOf<PlaylistEntryVm, NotFound>>
{
    /// <summary>
    /// Room id.
    /// </summary>
    public string RoomId { get; init; }

    /// <summary>
    /// Search term.
    /// </summary>
    public string Search { get; init; }
}