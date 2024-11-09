using MediatR;
using OneOf;
using OneOf.Types;

namespace PartyMix.Application.PlaylistEntries.Queries.GetPlaylistEntry;

/// <summary>
/// Query to get playlist entry by id.
/// </summary>
public class GetPlaylistEntryQuery : IRequest<OneOf<FileStream, NotFound>>
{
    /// <summary>
    /// Playlist entry id.
    /// </summary>
    public int Id { get; init; }
}