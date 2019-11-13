using System.Collections.Generic;
using System.Threading.Tasks;
using Coworking.Api.Bussiness.Models;

namespace Coworking.Application.Contracts.Services
{
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetAllOffices();
        Task<Office> GetOffice(int id);
        Task<Office> AddOffice(Office office);
        Task DeleteOffice(int id);
        Task<Office> UpdateOffice(Office office);
    }
}