using Pugna.Core.Rooms;
public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAllRoomsAsync();
    Task<Room?> GetRoomByIdAsync(int id);
    Task<Room> CreateRoomAsync(Room room);
    Task<Room?> UpdateRoomAsync(Room room);
    Task<bool> DeleteRoomAsync(int id);
}