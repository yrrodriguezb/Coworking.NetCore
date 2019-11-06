using Api.DataAccess.Contracts.Entities;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Api.DataAccess
{
    public static class AdminMapper
    {
        public static AdminEntity Map(Admin dto)
        {
            return new AdminEntity()
            {
                Email = dto.Email,
                Id = dto.Id,
                Name = dto.Name,
                OfficeId = dto.OfficeId,
                Phone = dto.Phone
            };
        }

        public static Admin Map(AdminEntity entity)
        {
            return new Admin()
            {
                Email = entity.Email,
                Id = entity.Id,
                Name = entity.Name,
                OfficeId = entity.OfficeId,
                Phone = entity.Phone
            };
        }
    }
}