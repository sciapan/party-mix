using PartyMix.Application.PlaylistEntries.Commands.CreatePlaylistEntry;
using PartyMix.Contracts;
using PartyMix.Domain.Entities;

namespace PartyMix.Application.PlaylistEntries;

public static class PlaylistEntryMapper
{
    public static PlaylistEntry ToPlaylistEntry(this CreatePlaylistEntryCommand command)
    {
        return new PlaylistEntry
        {
            RoomId = Ulid.Parse(command.RoomId),
            Order = command.Order,
            Singer = command.Singer,
            Song = command.Song
        };
    }

    public static PlaylistEntryVm ToVm(this PlaylistEntry playlistEntry)
    {
        return new PlaylistEntryVm
        {
            Id = playlistEntry.Id,
            RoomId = playlistEntry.RoomId.ToString(),
            Order = playlistEntry.Order,
            Singer = playlistEntry.Singer,
            Song = playlistEntry.Song
        };
    }
}