using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FlowersStore.DataAccess.MSSQL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly APIFlowersStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(APIFlowersStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddRange(List<Order> orderList)
        {
            var entityOrders = _mapper.Map<List<Core.CoreModels.Order>, List<Entities.Order>>(orderList);

            await _context.Orders.AddRangeAsync(entityOrders);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Order[]> Get()
        {
            var orders = await _context.Orders.ToArrayAsync();

            return _mapper.Map<Entities.Order[], Core.CoreModels.Order[]>(orders);
        }

        public async Task<Order[]> GetByUserId(int userId)
        {
            var orders = await _context.Orders
                       .Where(x => x.UserId == userId)
                       .AsNoTracking()
                       .ToArrayAsync();

            return _mapper.Map<Entities.Order[], Core.CoreModels.Order[]>(orders);
        }

        public async Task<Product[]> GetProducts()
        {
            var products = await _context.Products.ToArrayAsync();

            return _mapper.Map<Entities.Product[], Core.CoreModels.Product[]>(products);
        }

        public async Task<Product[]> GetProductsByUserId(int userId)
        {
            var products = await _context.Products
                .Where(f => f.UserId == userId)
                .ToArrayAsync();

            return _mapper.Map<Entities.Product[], Core.CoreModels.Product[]>(products);
        }
    }
}
