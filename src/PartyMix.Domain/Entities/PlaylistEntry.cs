﻿namespace PartyMix.Domain.Entities;

/// <summary>
/// Stores playlist entry.
/// </summary>
public class PlaylistEntry
{
    #region Properties

    /// <summary>
    /// Id. Unique identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Room id.
    /// </summary>
    public Ulid RoomId { get; set; }

    /// <summary>
    /// Playlist entry order.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Singer.
    /// </summary>
    public string Singer { get; set; }

    /// <summary>
    /// Song.
    /// </summary>
    public string Song { get; set; }

    #endregion

    #region Navigation properties

    /// <summary>
    /// Navigation property to related room entity.
    /// </summary>
    public Room Room { get; set; }

    #endregion
}