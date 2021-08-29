using System.Threading.Tasks;
using API_FlowersStore.Core.CoreModels;

namespace API_FlowersStore.Core.Services
{
    public interface IProductService
    {
        Task<string> Create(Product newProduct);
        Task<string> Update(Product product);
        Task<Product[]> Get();
        Task<bool> Delete(string productName);
    }
}
