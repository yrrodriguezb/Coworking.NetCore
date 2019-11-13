using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        // CRUD => CREATE, READ, UPDATE, DELETE
        private readonly ICoworkingDataContext _coworkingDbContext;

        public UserRepository(ICoworkingDataContext coworkingDbContext)
        {
            _coworkingDbContext = coworkingDbContext;
        }

        public async Task<UserEntity> Add(UserEntity entity) 
        { 
            await _coworkingDbContext.Users.AddAsync(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UserEntity> Update(int idEntity, UserEntity updateEntity) 
        { 
            var entity = await Get(idEntity);

            entity.Name = updateEntity.Name;

            _coworkingDbContext.Users.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UserEntity> Update(UserEntity entity) 
        { 
            var updateEntity =_coworkingDbContext.Users.Update(entity);
            await _coworkingDbContext.SaveChangesAsync();
            return updateEntity.Entity;
        }

        public async Task<UserEntity> Get(int idEntity) 
        { 
            var result = await _coworkingDbContext
                .Users
                .FirstOrDefaultAsync(a => a.Id == idEntity);
            
            return result;
        }

        public Task<bool> Exists(int id)
        {
            return _coworkingDbContext.Users.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _coworkingDbContext.Users.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDbContext
                .Users
                .SingleAsync(a => a.Id == id);

            _coworkingDbContext.Users.Remove(entity);
            await _coworkingDbContext.SaveChangesAsync();
        }
    }
}