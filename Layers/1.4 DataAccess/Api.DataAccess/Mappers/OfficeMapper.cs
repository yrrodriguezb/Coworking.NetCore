using Api.DataAccess.Contracts.Entities;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Api.DataAccess
{
    public static class OfficeMapper
    {
        public static OfficeEntity Map(Office dto)
        {
            return new OfficeEntity()
            {
                Active = dto.Active,
                Address = dto.Address,
                City = dto.City,
                HasIndividualWorkSpace = dto.HasIndividualWorkSpace,
                Id = dto.Id,
                IdAdmin = dto.IdAdmin,
                Name = dto.Name,
                NumberWorkSpaces = dto.NumberWorkSpaces,
                Phone = dto.Phone,
                PriceWorkSpaceDaily = dto.PriceWorkSpaceDaily,
                PriceWorkSpaceMonthly = dto.PriceWorkSpaceMonthly
            };
        }

        public static Office Map(OfficeEntity entity)
        {
            return new Office()
            {
                Active = entity.Active,
                Address = entity.Address,
                City = entity.City,
                HasIndividualWorkSpace = entity.HasIndividualWorkSpace,
                Id = entity.Id,
                IdAdmin = entity.IdAdmin,
                Name = entity.Name,
                NumberWorkSpaces = entity.NumberWorkSpaces,
                Phone = entity.Phone,
                PriceWorkSpaceDaily = entity.PriceWorkSpaceDaily,
                PriceWorkSpaceMonthly = entity.PriceWorkSpaceMonthly
            };
        }
    }
}