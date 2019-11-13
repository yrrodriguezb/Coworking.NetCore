using Api.DataAccess.Contracts.Entities;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Api.DataAccess
{
    public static class RoomMapper
    {
        public static RoomEntity Map(Room dto)
        {
            return new RoomEntity()
            {
                Capacity = dto.Capacity,
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static Room Map(RoomEntity entity)
        {
            return new Room()
            {
                Id = entity.Id,
                Capacity = entity.Capacity,
                Name = entity.Name
            };
        }
    }
}