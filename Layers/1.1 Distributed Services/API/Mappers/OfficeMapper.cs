using System;
using Coworking.Api.Bussiness.Models;
using Coworking.API.ViewModels;

namespace Coworking.API.Mappers
{
    public class OfficeMapper
    {
        public static Office Map(OfficeModel model)
        {
            return new Office () 
            {
                Active = model.Active,
                Address = model.Address,
                City = model.City,
                HasIndividualWorkSpace = model.HasIndividualWorkSpace,
                Id = model.Id,
                IdAdmin = model.IdAdmin,
                Name = model.Name,
                NumberWorkSpaces = model.NumberWorkSpaces,
                Phone = model.Phone,
                PriceWorkSpaceDaily = model.PriceWorkSpaceDaily,
                PriceWorkSpaceMonthly = model.PriceWorkSpaceMonthly
            };
        }
    }
}