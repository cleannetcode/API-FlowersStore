using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Services;
using System;
using System.Threading.Tasks;

namespace API_FlowersStore.BusinessLogic
{
    public class OrderService : IOrderService
    {
        public Task<Product[]> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Product[]> GetByProvider(User user)
        {
            throw new NotImplementedException();
        }
    }
}
