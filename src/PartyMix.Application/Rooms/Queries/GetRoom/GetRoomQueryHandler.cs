﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using PartyMix.Contracts;
using PartyMix.Persistence;

namespace PartyMix.Application.Rooms.Queries.GetRoom;

public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, OneOf<RoomVm, NotFound>>
{
    #region Fields

    private readonly PartyMixDbContext _dbContext;

    #endregion

    #region Ctor

    public GetRoomQueryHandler(PartyMixDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion

    #region Methods

    public async Task<OneOf<RoomVm, NotFound>> Handle(GetRoomQuery request, CancellationToken cancellationToken)
    {
        var room = await _dbContext.Rooms
            .Include(x => x.PlaylistEntries)
            .FirstOrDefaultAsync(x => x.Id == Ulid.Parse(request.Id), cancellationToken);
        
        if (room == null)
        {
            return new NotFound();
        }

        return room.ToVm();
    }

    #endregion
}