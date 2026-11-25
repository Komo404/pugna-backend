using Npgsql;
using Pugna.Core.Rooms;

namespace Pugna.Infra.Persistence;

public class RoomRepository : IRoomRepository
{
    private readonly NpgsqlDataSource _dataSource;
    
    public RoomRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }   

    public async Task<IEnumerable<Room>> GetAllRoomsAsync()
    {
        await using var command = _dataSource.CreateCommand("SELECT * FROM rooms");
        await using var reader = await command.ExecuteReaderAsync();

        var rooms = new List<Room>();

        while (await reader.ReadAsync())
        {
            rooms.Add(new Room
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Capacity = reader.GetInt32(3)
            });
        }

        return rooms;
    }

    public async Task<Room?> GetRoomByIdAsync(int id)
    {
        await using var command = _dataSource.CreateCommand("SELECT * FROM rooms WHERE id = @id");
        command.Parameters.AddWithValue("id", id);

        await using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        return new Room
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Description = reader.GetString(2),
            Capacity = reader.GetInt32(3)
        };
    }

    public async Task<Room> CreateRoomAsync(Room room)
    {
        await using var command = _dataSource.CreateCommand("INSERT INTO rooms (name, description, capacity) VALUES (@name, @description, @capacity) RETURNING id");
        command.Parameters.AddWithValue("name", room.Name); //addwithvalue adds a parameter to the command with the specified name and value, so it can use a variable
        command.Parameters.AddWithValue("description", room.Description);
        command.Parameters.AddWithValue("capacity", room.Capacity);

        var id = (int)(await command.ExecuteScalarAsync() ?? throw new InvalidOperationException("Failed to create room.")); // returns the value of the first column of the first row in the result set. 
        room.Id = id;

        return room;
    }

    public async Task<Room?> UpdateRoomAsync(Room room)
    {
        await using var command = _dataSource.CreateCommand("UPDATE rooms SET name = @name, description = @description, capacity = @capacity WHERE id = @id RETURNING *");
        command.Parameters.AddWithValue("id", room.Id);
        command.Parameters.AddWithValue("name", room.Name);
        command.Parameters.AddWithValue("description", room.Description);
        command.Parameters.AddWithValue("capacity", room.Capacity);

        await using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
        {
            return null;
        }

        return new Room
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Description = reader.GetString(2),
            Capacity = reader.GetInt32(3)
        };
    }

    public async Task<bool> DeleteRoomAsync(int id)
    {
        await using var command = _dataSource.CreateCommand("DELETE FROM rooms WHERE id = @id");
        command.Parameters.AddWithValue("id", id);

        var rowsAffected = await command.ExecuteNonQueryAsync(); // RETURNS the number of rows affected by the command.

        if (rowsAffected > 0) return true;
        return false;
    }
}