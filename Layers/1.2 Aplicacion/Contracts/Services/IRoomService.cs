using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Application.Contracts.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoom(int id);
        Task<Room> AddRoom(Room room);
        Task DeleteRoom(int id);
        Task<Room> UpdateRoom(Room room);
    }
}