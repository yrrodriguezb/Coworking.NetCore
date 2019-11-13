using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.API.Mappers;
using Coworking.API.ViewModels;
using Coworking.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>
        /// GET all Room
        /// </summary>
        /// <returns>Room Collection</returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<AdminModel>))]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(rooms);
        }

        /// <summary>
        /// GET a Room
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Room</returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(RoomModel))]
        public async Task<IActionResult> Get(int id)
        {
            var room = await _roomService.GetRoom(id);
            return Ok(room);
        }

        /// <summary>
        /// Add a new room
        /// </summary>
        /// <param name="room"></param>
        /// <returns>Room</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(RoomModel))]
        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] RoomModel room)
        {
            var newRoom = await _roomService.AddRoom(RoomMapper.Map(room));
            return Ok(newRoom);
        }

        /// <summary>
        /// Delete a room
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoom(id);
            return Ok();
        }

        /// <summary>
        /// Update a room
        /// </summary>
        /// <param name="room"></param>
        /// <returns>Room</returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(RoomModel))]
        public async Task<IActionResult> UpdateRoom([FromBody]RoomModel room)
        {
            var updatedRoom = await _roomService.UpdateRoom(RoomMapper.Map(room));
            return Ok(updatedRoom);
        }

    }
}