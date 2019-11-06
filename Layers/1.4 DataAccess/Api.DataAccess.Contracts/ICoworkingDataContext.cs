using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.DataAccess.Contracts
{
    public interface ICoworkingDataContext 
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<AdminEntity> Admins { get; set; }
        DbSet<BookingEntity> Bookings { get; set; }
        DbSet<OfficeEntity> Offices { get; set; }
        DbSet<Office2RoomsEntity> Office2Rooms { get; set; }
        DbSet<Room2ServiceEntity> Room2Services { get; set; }
        DbSet<RoomEntity> Rooms { get; set; }
        DbSet<ServiceEntity> Services { get; set; }


        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken CancellationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);

    }
}