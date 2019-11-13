using System;
using Coworking.Api.Bussiness.Models;
using Coworking.API.ViewModels;

namespace Coworking.API.Mappers
{
    public class BookingMapper
    {
        public static Booking Map(BookingModel model)
        {
            return new Booking()
            {
                RentWorkSpace = model.RentWorkSpace,
                Id = model.Id,
                CreateDate = model.CreateDate,
                BookingDate = model.BookingDate,
                OfficeId = model.OfficeId,
                RoomId = model.RoomId,
                UserId = model.UserId
            };
        }
    }
}