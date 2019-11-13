using System;
using Coworking.Api.Bussiness.Models;
using Coworking.API.ViewModels;

namespace Coworking.API.Mappers
{
    public class AdminMapper
    {
        public static Admin Map(AdminModel model)
        {
            return new Admin () 
            {
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone,
                HireDate = DateTime.Now
            };
        }
    }
}