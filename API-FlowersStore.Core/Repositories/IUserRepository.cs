using API_FlowersStore.Core.CoreModels;
using System.Threading.Tasks;

namespace API_FlowersStore.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User[]> GetAll();
        Task<User> GetByNameAndPassword(string name, string password);
        Task<User> GetById(int id);
    }
}
