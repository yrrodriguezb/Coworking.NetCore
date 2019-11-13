using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DataAccess.Contracts.Repositories;
using Coworking.Api.Bussiness.Models;
using Coworking.Api.DataAccess;
using Coworking.Application.Contracts.Services;

namespace Coworking.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> GetRoom(int id)
        {
            var entity = await _roomRepository.Get(id);
            return RoomMapper.Map(entity);
        }

        public async Task<Room> AddRoom(Room room)
        {
            var addedEntity = await _roomRepository.Add(RoomMapper.Map(room));
            return RoomMapper.Map(addedEntity);
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = await _roomRepository.GetAll();
            return rooms.Select(RoomMapper.Map);
        }

        public Task DeleteRoom(int id)
        {
            return  _roomRepository.DeleteAsync(id); 
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            var updated = await _roomRepository.Update(RoomMapper.Map(room));
            return RoomMapper.Map(updated);
        }
    }
}