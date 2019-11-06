using System.Threading.Tasks;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.Contracts.Repositories
{
    public interface IRoomRepository : IRepository<RoomEntity>
    {
        Task<RoomEntity> Update(RoomEntity entity);
    }
}