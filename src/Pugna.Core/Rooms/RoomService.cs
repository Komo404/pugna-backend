// Manages the lifecycle of a room

namespace Pugna.Core.Rooms;

public class RoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<IEnumerable<Room>> GetAllRoomsAsync()
    {
        return await _roomRepository.GetAllRoomsAsync();
    }

    public async Task<Room?> GetRoomByIdAsync(int id)
    {
        return await _roomRepository.GetRoomByIdAsync(id);
    }

    public async Task<Room?> UpdateRoomAsync(Room room)
    {
        return await _roomRepository.UpdateRoomAsync(room);
    }

    public async Task<bool> DeleteRoomAsync(int id)
    {
        return await _roomRepository.DeleteRoomAsync(id);
    }

    public async Task<Room> CreateRoomAsync(Room room)
    {
        return await _roomRepository.CreateRoomAsync(room);
    }

    public async Task<Room?> JoinRoomAsync(int roomId, Guid playerId)
    {
        var room = await _roomRepository.GetRoomByIdAsync(roomId);
        if (room == null) return null;

        if (room.PlayerIds.Count >= room.Capacity) return null;

        if (!room.PlayerIds.Any(p => p == playerId))
        {
            room.PlayerIds.Add(playerId);
        }

        return await _roomRepository.UpdateRoomAsync(room);
    }

    public async Task<Room?> LeaveRoomAsync(int roomId, Guid playerId)
    {
        var room = await _roomRepository.GetRoomByIdAsync(roomId);
        if (room == null) return null;

        room.PlayerIds.RemoveAll(p => p == playerId);

        return await _roomRepository.UpdateRoomAsync(room);
    }
}