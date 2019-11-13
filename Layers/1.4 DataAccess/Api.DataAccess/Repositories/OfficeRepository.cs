using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        // CRUD => CREATE, READ, UPDATE, DELETE
        private readonly ICoworkingDataContext _coworkingDbContext;

        public OfficeRepository(ICoworkingDataContext coworkingDbContext)
        {
            _coworkingDbContext = coworkingDbContext;
        }

        public async Task<OfficeEntity> Add(OfficeEntity entity) 
        { 
            await _coworkingDbContext.Offices.AddAsync(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<OfficeEntity> Update(int idEntity, OfficeEntity updateEntity) 
        { 
            var entity = await Get(idEntity);

            entity.Name = updateEntity.Name;

            _coworkingDbContext.Offices.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<OfficeEntity> Update(OfficeEntity entity) 
        { 
            var updateEntity =_coworkingDbContext.Offices.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return updateEntity.Entity;
        }

        public async Task<OfficeEntity> Get(int idEntity) 
        { 
            var result = await _coworkingDbContext
                .Offices
                .FirstOrDefaultAsync(a => a.Id == idEntity);
            
            return result;
        }

        public Task<bool> Exists(int id)
        {
            return _coworkingDbContext.Offices.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<OfficeEntity>> GetAll()
        {
            return await _coworkingDbContext.Offices.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDbContext
                .Offices
                .SingleAsync(a => a.Id == id);

            _coworkingDbContext.Offices.Remove(entity);
            await _coworkingDbContext.SaveChangesAsync();
        }
    }
}