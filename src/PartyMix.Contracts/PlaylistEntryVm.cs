namespace PartyMix.Contracts;

/// <summary>
/// VM of playlist entry entity.
/// </summary>
public record PlaylistEntryVm
{
    /// <summary>
    /// Id. Unique identifier.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Room id.
    /// </summary>
    public string RoomId { get; init; }

    /// <summary>
    /// Playlist entry order.
    /// </summary>
    public int Order { get; init; }

    /// <summary>
    /// Singer.
    /// </summary>
    public string Singer { get; init; }

    /// <summary>
    /// Song.
    /// </summary>
    public string Song { get; init; }
}