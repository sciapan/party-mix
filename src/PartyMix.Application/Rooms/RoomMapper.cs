using PartyMix.Application.Rooms.Commands.CreateRoom;
using PartyMix.Contracts;
using PartyMix.Domain.Entities;

namespace PartyMix.Application.Rooms;

public static class RoomMapper
{
    public static Room ToRoom(this CreateRoomCommand command)
    {
        return new Room { Name = command.Name };
    }

    public static RoomVm ToVm(this Room room)
    {
        return new RoomVm { Id = room.Id.ToString(), Name = room.Name, Link = $"https://party.mix/{room.Id}" };
    }
}