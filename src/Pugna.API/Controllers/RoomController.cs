using Microsoft.AspNetCore.Mvc;
using Pugna.Core.Rooms;

namespace Pugna.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly RoomService _roomService;

    public RoomController(RoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet(Name = "Get Room")]
    public async Task<IEnumerable<Room>> GetGetAllRooms()
    {
        return await _roomService.GetAllRoomsAsync();
    }

    [HttpGet("{id}", Name = "Get Room By Id")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _roomService.GetRoomByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPost(Name = "Create Room")]
    public async Task<IActionResult> Post([FromBody] Room room)
    {
        if (room.Capacity <= 0)
        {
            return BadRequest("Capacity must be greater than 0");
        }

        var createdRoom = await _roomService.CreateRoomAsync(room);
        return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
    }

    [HttpPut(Name = "Update Room")]
    public async Task<IActionResult> Put([FromBody] Room room)
    {
        if (room.Capacity <= 0)
        {
            return BadRequest("Capacity must be greater than 0");
        }
        
        var updatedRoom = await _roomService.UpdateRoomAsync(room);
        if (updatedRoom == null)
        {
            return NotFound();
        }
        return Ok(updatedRoom);
    }

    [HttpDelete(Name = "Delete Room")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _roomService.DeleteRoomAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}