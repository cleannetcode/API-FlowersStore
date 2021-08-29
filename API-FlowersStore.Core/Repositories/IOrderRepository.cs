using API_FlowersStore.Core.CoreModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_FlowersStore.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> AddRange(List<Order> orderList);

        Task<Order[]> Get();

        Task<Order[]> GetByUserId(int userId);

        Task<Product[]> GetProducts();

        Task<Product[]> GetProductsByUserId(int userId);
    }
}
