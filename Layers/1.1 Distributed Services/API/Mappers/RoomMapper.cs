using System;
using Coworking.Api.Bussiness.Models;
using Coworking.API.ViewModels;

namespace Coworking.API.Mappers
{
    public class RoomMapper
    {
        public static Room Map(RoomModel model)
        {
            return new Room () 
            {
                Capacity = model.Capacity,
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}