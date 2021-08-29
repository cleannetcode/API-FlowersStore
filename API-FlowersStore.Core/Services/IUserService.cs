using System.Threading.Tasks;
using API_FlowersStore.Core.CoreModels;

namespace API_FlowersStore.Core.Services
{
    public interface IUserService
    {
        Task<User[]> GetAll();
        Task<User> GetByNameAndPassword(string name, string password);
        Task<User> GetById(int id);
    }
}
