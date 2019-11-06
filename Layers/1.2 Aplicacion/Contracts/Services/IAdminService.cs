using System.Threading.Tasks;

namespace Coworking.Application.Contracts.Services
{
    public interface IAdminService
    {
        Task<string> GetAdminName(int id);
    }
}