using System;
using Coworking.Api.Bussiness.Models;
using Coworking.API.ViewModels;

namespace Coworking.API.Mappers
{
    public class ServiceMapper
    {
        public static Service Map(ServiceModel model)
        {
            return new Service () 
            {
                Active = model.Active,
                Id = model.Id,
                Name = model.Name,
                Price = model.Price
            };
        }
    }
}