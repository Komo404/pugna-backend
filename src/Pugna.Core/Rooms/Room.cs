namespace Pugna.Core.Rooms;

public class Room
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = "";
    public required int Capacity { get; set; }
    public List<Guid> PlayerIds { get; set; } = new();
    public enum RoomStatus { Open, Closed, InGame }
}