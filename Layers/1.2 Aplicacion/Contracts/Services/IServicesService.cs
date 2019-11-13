using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Application.Contracts.Services
{
    public interface IServicesService
    {
        Task<IEnumerable<Service>> GetAllServices();
        Task<Service> GetService(int id);
        Task<Service> AddService(Service service);
        Task DeleteService(int id);
        Task<Service> UpdateService(Service service);
    }
}