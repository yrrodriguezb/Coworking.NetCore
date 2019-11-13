using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        // CRUD => CREATE, READ, UPDATE, DELETE
        private readonly ICoworkingDataContext _coworkingDbContext;

        public RoomRepository(ICoworkingDataContext coworkingDbContext)
        {
            _coworkingDbContext = coworkingDbContext;
        }

        public async Task<RoomEntity> Add(RoomEntity entity) 
        { 
            await _coworkingDbContext.Rooms.AddAsync(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<RoomEntity> Update(int idEntity, RoomEntity updateEntity) 
        { 
            var entity = await Get(idEntity);

            entity.Name = updateEntity.Name;

            _coworkingDbContext.Rooms.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<RoomEntity> Update(RoomEntity entity) 
        { 
            var updateEntity =_coworkingDbContext.Rooms.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return updateEntity.Entity;
        }

        public async Task<RoomEntity> Get(int idEntity) 
        { 
            var result = await _coworkingDbContext
                .Rooms
                .FirstOrDefaultAsync(a => a.Id == idEntity);
            
            return result;
        }

        public Task<bool> Exists(int id)
        {
            return _coworkingDbContext.Rooms.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<RoomEntity>> GetAll()
        {
            return await _coworkingDbContext.Rooms.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDbContext
                .Rooms
                .SingleAsync(a => a.Id == id);

            _coworkingDbContext.Rooms.Remove(entity);
            await _coworkingDbContext.SaveChangesAsync();
        }
    }
}