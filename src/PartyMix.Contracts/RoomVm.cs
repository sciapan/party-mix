namespace PartyMix.Contracts;

/// <summary>
/// VM of room entity.
/// </summary>
public record RoomVm
{
    /// <summary>
    /// Id. Unique identifier.
    /// </summary>
    public string Id { get; init; }

    /// <summary>
    /// Room name.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Room link.
    /// </summary>
    public string Link { get; init; }

    /// <summary>
    /// Room playlist.
    /// </summary>
    public PlaylistEntryVm[]? Playlist { get; init; }
}