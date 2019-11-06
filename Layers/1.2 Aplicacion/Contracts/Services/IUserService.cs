using System.Threading.Tasks;

namespace Coworking.Application.Contracts.Services
{
    public interface IUserService
    {
        Task GetUserName(int idUser, int idAdmin);
    }
}