using System.Threading.Tasks;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.Contracts.Repositories
{
    public interface IBookingRepository : IRepository<BookingEntity>
    {
        Task<BookingEntity> Update(BookingEntity entity);
    }
}