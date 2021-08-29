using System.Threading.Tasks;
using API_FlowersStore.Core.CoreModels;

namespace API_FlowersStore.Core.Services
{
    public interface IProductService
    {
        Task<string> Create(Product newProduct);

        Task<string> Update(Product product);

        Task<Product[]> Get(int userId);

        Task<Product> GetByProductName(string productName, int userId);

        Task<Product[]> GetByOrders(int[] ordersId);

        Task<bool> Delete(string productName, int userId);
    }
}
