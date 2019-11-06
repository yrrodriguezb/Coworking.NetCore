using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.EntityConfig;

namespace Api.DataAccess
{
    public class CoworkingDataContext : DbContext, ICoworkingDataContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<OfficeEntity> Offices { get; set; }
        public DbSet<Office2RoomsEntity> Office2Rooms { get; set; }
        public DbSet<Room2ServiceEntity> Room2Services { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
      
        public CoworkingDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AdminEntityConfig.SetEntityBuilder(modelBuilder.Entity<AdminEntity>());
            BookingEntityConfig.SetEntityBuilder(modelBuilder.Entity<BookingEntity>());
            Office2RoomEntityConfig.SetEntityBuilder(modelBuilder.Entity<Office2RoomsEntity>());
            OfficeEntityConfig.SetEntityBuilder(modelBuilder.Entity<OfficeEntity>());
            Room2ServiceEntityConfig.SetEntityBuilder(modelBuilder.Entity<Room2ServiceEntity>());
            RoomEntityConfig.SetEntityBuilder(modelBuilder.Entity<RoomEntity>());
            ServiceEntityConfig.SetEntityBuilder(modelBuilder.Entity<ServiceEntity>());
            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<UserEntity>());

            
            base.OnModelCreating(modelBuilder);
        }
    }
}