using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        // CRUD => CREATE, READ, UPDATE, DELETE
        private readonly ICoworkingDataContext _coworkingDbContext;

        public BookingRepository(ICoworkingDataContext coworkingDbContext)
        {
            _coworkingDbContext = coworkingDbContext;
        }

        public async Task<BookingEntity> Add(BookingEntity entity) 
        { 
            await _coworkingDbContext.Bookings.AddAsync(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<BookingEntity> Update(int idEntity, BookingEntity updateEntity) 
        { 
            var entity = await Get(idEntity);

            entity.RentWorkSpace = updateEntity.RentWorkSpace;

            _coworkingDbContext.Bookings.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<BookingEntity> Update(BookingEntity entity) 
        { 
            var updateEntity =_coworkingDbContext.Bookings.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return updateEntity.Entity;
        }

        public async Task<BookingEntity> Get(int idEntity) 
        { 
            var result = await _coworkingDbContext
                .Bookings
                .FirstOrDefaultAsync(a => a.Id == idEntity);
            
            return result;
        }

        public Task<bool> Exists(int id)
        {
            return _coworkingDbContext.Bookings.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<BookingEntity>> GetAll()
        {
            return await _coworkingDbContext.Bookings.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDbContext
                .Bookings
                .SingleAsync(a => a.Id == id);

            _coworkingDbContext.Bookings.Remove(entity);
            await _coworkingDbContext.SaveChangesAsync();
        }
    }
}