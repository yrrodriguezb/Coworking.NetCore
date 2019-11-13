using System.Threading.Tasks;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.Contracts.Repositories
{
    public interface IServiceRepository : IRepository<ServiceEntity>
    {
        Task<ServiceEntity> Update(ServiceEntity entity);
    }
}