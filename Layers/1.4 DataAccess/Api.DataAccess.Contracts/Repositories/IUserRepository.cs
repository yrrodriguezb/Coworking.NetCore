using System.Threading.Tasks;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.Contracts.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> Update(UserEntity entity);
    }
}