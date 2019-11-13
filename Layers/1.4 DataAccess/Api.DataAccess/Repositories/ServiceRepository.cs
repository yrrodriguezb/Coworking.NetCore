using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        // CRUD => CREATE, READ, UPDATE, DELETE
        private readonly ICoworkingDataContext _coworkingDbContext;

        public ServiceRepository(ICoworkingDataContext coworkingDbContext)
        {
            _coworkingDbContext = coworkingDbContext;
        }

        public async Task<ServiceEntity> Add(ServiceEntity entity) 
        { 
            await _coworkingDbContext.Services.AddAsync(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ServiceEntity> Update(int idEntity, ServiceEntity updateEntity) 
        { 
            var entity = await Get(idEntity);

            entity.Name = updateEntity.Name;

            _coworkingDbContext.Services.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ServiceEntity> Update(ServiceEntity entity) 
        { 
            var updateEntity =_coworkingDbContext.Services.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return updateEntity.Entity;
        }

        public async Task<ServiceEntity> Get(int idEntity) 
        { 
            var result = await _coworkingDbContext
                .Services
                .FirstOrDefaultAsync(a => a.Id == idEntity);
            
            return result;
        }

        public Task<bool> Exists(int id)
        {
            return _coworkingDbContext.Services.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<ServiceEntity>> GetAll()
        {
            return await _coworkingDbContext.Services.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDbContext
                .Services
                .SingleAsync(a => a.Id == id);

            _coworkingDbContext.Services.Remove(entity);
            await _coworkingDbContext.SaveChangesAsync();
        }
    }
}