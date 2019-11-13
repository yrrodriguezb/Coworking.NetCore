using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;
using System.Linq;

namespace Api.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        // CRUD => CREATE, READ, UPDATE, DELETE
        private readonly ICoworkingDataContext _coworkingDbContext;

        public AdminRepository(ICoworkingDataContext coworkingDbContext)
        {
            _coworkingDbContext = coworkingDbContext;
        }

        public async Task<AdminEntity> Add(AdminEntity entity) 
        { 
            await _coworkingDbContext.Admins.AddAsync(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<AdminEntity> Update(int idEntity, AdminEntity updateEntity) 
        { 
            var entity = await Get(idEntity);

            entity.Name = updateEntity.Name;

            _coworkingDbContext.Admins.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<AdminEntity> Update(AdminEntity entity) 
        { 
            var updateEntity =_coworkingDbContext.Admins.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return updateEntity.Entity;
        }

        public async Task<AdminEntity> Get(int idEntity) 
        { 
            var result = await _coworkingDbContext.Admins
                .FirstOrDefaultAsync(a => a.Id == idEntity);
            
            return result;
        }

        public Task<bool> Exists(int id)
        {
            return _coworkingDbContext.Admins.AnyAsync(a => a.Id == id);
        }

        public async  Task<IEnumerable<AdminEntity>> GetAll()
        {
            return await _coworkingDbContext.Admins.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDbContext
                .Admins
                .SingleAsync(a => a.Id == id);

            _coworkingDbContext.Admins.Remove(entity);
            await _coworkingDbContext.SaveChangesAsync();
        }
    }
}