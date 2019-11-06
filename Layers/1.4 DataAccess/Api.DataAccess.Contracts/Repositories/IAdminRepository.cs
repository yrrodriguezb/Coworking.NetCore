using System.Threading.Tasks;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.Contracts.Repositories
{
    public interface IAdminRepository : IRepository<AdminEntity>
    {
        Task<AdminEntity> Update(AdminEntity entity);
    }
}