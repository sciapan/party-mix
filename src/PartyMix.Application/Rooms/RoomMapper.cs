using PartyMix.Application.Rooms.Models;
using PartyMix.Domain;
using PartyMix.Application.Rooms.Commands;
namespace PartyMix.Application.Rooms;

public static class RoomMapper
{
    public static Room ToRoom(this CreateRoomCommand command)
    {
        return new Room { Name = command.Name };
    }

    public static RoomVm ToVm(this Room room)
    {
        return new RoomVm { Id = room.Id, Name = room.Name };
    }
}