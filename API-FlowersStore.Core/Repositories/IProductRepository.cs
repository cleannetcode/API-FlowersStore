using API_FlowersStore.Core.CoreModels;
using System.Threading.Tasks;

namespace API_FlowersStore.Core.Repositories
{
    public interface IProductRepository
    {
        Task<string> Add(Product newProduct);
        Task<string> Update(Product product);
        Task<Product[]> Get();
        Task<bool> Delete(string productName);
    }
}
