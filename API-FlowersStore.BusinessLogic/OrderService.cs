using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Repositories;
using API_FlowersStore.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_FlowersStore.BusinessLogic
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Create(List<Order> orderList)
        {
            if (orderList == null)
            {
                throw new ArgumentNullException(nameof(orderList));
            }

            return await _orderRepository.AddRange(orderList);
        }

        public async Task<Order[]> Get()
        {
            return await _orderRepository.Get();
        }

        public async Task<Order[]> GetByUserId(int userId)
        {
            if (userId <= (int)default)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return await _orderRepository.GetByUserId(userId);
        }

        public async Task<Product[]> GetProducts()
        {
            return await _orderRepository.GetProducts();
        }

        public async Task<Product[]> GetProductsByUserId(int userId)
        {
            if (userId <= (int)default)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return await _orderRepository.GetProductsByUserId(userId);
        }
    }
}