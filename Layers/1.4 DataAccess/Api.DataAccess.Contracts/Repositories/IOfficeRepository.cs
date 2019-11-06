using System.Threading.Tasks;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.Contracts.Repositories
{
    public interface IOfficeRepository : IRepository<OfficeEntity>
    {
        Task<OfficeEntity> Update(OfficeEntity entity);
    }
}