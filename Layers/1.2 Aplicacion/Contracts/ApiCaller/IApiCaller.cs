using System.Threading.Tasks;

namespace Coworking.Application.Contracts
{
    public interface IApiCaller
    {
        Task<T> GetServiceResponse<T>(string controller, int id);
    }
}