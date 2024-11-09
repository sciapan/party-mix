using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using PartyMix.Contracts;
using PartyMix.Domain.Entities;
using PartyMix.Persistence;

namespace PartyMix.Application.PlaylistEntries.Commands.CreatePlaylistEntry;

/// <summary>
/// Handler for <see cref="CreatePlaylistEntryCommand"/>.
/// </summary>
public class CreatePlaylistEntryCommandHandler : IRequestHandler<CreatePlaylistEntryCommand, OneOf<PlaylistEntryVm, NotFound>>
{
    #region Fields

    private readonly PartyMixDbContext _dbContext;

    #endregion
    
    #region Ctor
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CreatePlaylistEntryCommandHandler"/> class.
    /// </summary>
    /// <param name="dbContext"><see cref="PartyMixDbContext"/></param>
    public CreatePlaylistEntryCommandHandler(PartyMixDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    #endregion

    #region Methods

    /// <summary>
    /// Handles command.
    /// </summary>
    /// <param name="request"><see cref="CreatePlaylistEntryCommand"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Task{TResult}"/></returns>
    public async Task<OneOf<PlaylistEntryVm, NotFound>> Handle(CreatePlaylistEntryCommand request, CancellationToken cancellationToken)
    {
        var roomId = Ulid.Parse(request.RoomId);
        var room = await _dbContext.Rooms
            .Include(x => x.PlaylistEntries)
            .FirstOrDefaultAsync(x => x.Id == roomId, cancellationToken);

        if (room == null)
        {
            return new NotFound();
        }

        var playlistEntry = new PlaylistEntry
        {
            RoomId = roomId,
            Order = room.PlaylistEntries.Count, // last by default
            Artist = "Dummy Artist",
            Song = "Dummy Song",
            Url = room.PlaylistEntries.Count % 2 == 0 ? "sample-one.mp3" : "sample-two.mp3"
        };

        // TODO handle search 
        // should parse in result - artist / song
        
        // TODO handle source parsing

        _dbContext.PlaylistEntries.Add(playlistEntry);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return playlistEntry.ToVm();
    }

    #endregion
}