using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace API_FlowersStore.DataAccess.MSSQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIFlowersStoreDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(APIFlowersStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Add(Product newProduct)
        {
            if (newProduct is null)
            {
                throw new ArgumentNullException(nameof(newProduct));
            }

            var newProductEntity = _mapper.Map<Core.CoreModels.Product, Entities.Product>(newProduct);

            await _context.Products.AddAsync(newProductEntity);
            await _context.SaveChangesAsync();

            return newProductEntity.Name;
        }

        public Task<bool> Delete(string productName)
        {
            throw new NotImplementedException();
        }

        public async Task<Product[]> Get()
        {
            var members = await _context.Products
                       .AsNoTracking()
                       .ToArrayAsync();

            return _mapper.Map<Entities.Product[], Core.CoreModels.Product[]>(members);
        }

        public async Task<string> Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var memberEntity = _mapper.Map<Core.CoreModels.Product, Entities.Product>(product);

            _context.Products.Update(memberEntity);
            await _context.SaveChangesAsync();

            return product.Name;
        }
    }
}
