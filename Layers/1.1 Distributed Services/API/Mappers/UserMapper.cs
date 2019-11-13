using System;
using Coworking.Api.Bussiness.Models;
using Coworking.API.ViewModels;

namespace Coworking.API.Mappers
{
    public class UserMapper
    {
        public static User Map(UserModel model)
        {
            return new User () 
            {
                Active = model.Active,
                CreateDate = model.CreateDate,
                Email = model.Email,
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname
            };
        }
    }
}