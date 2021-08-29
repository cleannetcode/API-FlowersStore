using API_FlowersStore.Core.CoreModels;
using System.Threading.Tasks;

namespace API_FlowersStore.Core.Repositories
{
    public interface IProductRepository
    {
        Task<string> Add(Product newProduct);

        Task<string> Update(Product product);

        Task<Product[]> Get(int userId);

        Task<Product[]> GetByOrders(int[] ordersId);

        Task<bool> Delete(string productName, int userId);

        Task<Product> GetByName(string productName, int userId);
    }
}
