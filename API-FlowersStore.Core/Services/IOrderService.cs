using API_FlowersStore.Core.CoreModels;
using System.Threading.Tasks;

namespace API_FlowersStore.Core.Services
{
    public interface IOrderService
    {
        Task<Product[]> Get();

        Task<Product[]> GetByProvider(User user);
    }
}
