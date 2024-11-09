using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using PartyMix.Persistence;

namespace PartyMix.Application.PlaylistEntries.Queries.GetPlaylistEntry;

/// <summary>
/// Handler for the <see cref="GetPlaylistEntryQuery"/>.
/// </summary>
public class GetPlaylistEntryQueryHandler : IRequestHandler<GetPlaylistEntryQuery, OneOf<FileStream, NotFound>>
{
    #region Fields

    private readonly PartyMixDbContext _dbContext;

    #endregion

    #region Ctor

    /// <summary>
    /// Initializes a new instance of the <see cref="GetPlaylistEntryQueryHandler"/> class.
    /// </summary>
    /// <param name="dbContext"><see cref="PartyMixDbContext"/></param>
    public GetPlaylistEntryQueryHandler(PartyMixDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handles <see cref="GetPlaylistEntryQuery"/>.
    /// </summary>
    /// <param name="request"><see cref="GetPlaylistEntryQuery"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Task"/></returns>
    public async Task<OneOf<FileStream, NotFound>> Handle(GetPlaylistEntryQuery request, CancellationToken cancellationToken)
    {
        var playlistEntry = await _dbContext.PlaylistEntries.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (playlistEntry == null)
        {
            return new NotFound();
        }
        
        // TODO handle url
        var path = Path.Combine("D:", "projects", "party-mix", "src", "PartyMix.WebUI", "wwwroot", playlistEntry.Url);
        return new FileStream(path, FileMode.Open, FileAccess.Read);
    }

    #endregion
}