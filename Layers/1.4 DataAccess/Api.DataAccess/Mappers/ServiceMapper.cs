using Api.DataAccess.Contracts.Entities;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Api.DataAccess
{
    public static class ServiceMapper
    {
        public static ServiceEntity Map(Service dto)
        {
            return new ServiceEntity()
            {
                Id = dto.Id,
                Active = dto.Active,
                Name = dto.Name,
                Price = dto.Price
            };
        }

        public static Service Map(ServiceEntity entity)
        {
            return new Service()
            {
                Active = entity.Active,
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}