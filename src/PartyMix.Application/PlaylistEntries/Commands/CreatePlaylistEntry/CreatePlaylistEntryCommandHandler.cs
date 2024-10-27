using MediatR;
using OneOf;
using OneOf.Types;
using PartyMix.Contracts;
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
        var playlistEntry = request.ToPlaylistEntry();

        _dbContext.PlaylistEntries.Add(playlistEntry);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return playlistEntry.ToVm();
    }

    #endregion
}