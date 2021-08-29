using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Repositories;
using API_FlowersStore.Core.Services;
using System;
using System.Threading.Tasks;

namespace API_FlowersStore.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> Create(Product newProduct)
        {
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct));
            }

            var productName = await _productRepository.Add(newProduct);

            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            return productName;
        }

        public async Task<string> Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var productName = await _productRepository.Add(product);

            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            return productName;
        }

        public async Task<bool> Delete(string productName, int userId)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            return await _productRepository.Delete(productName, userId);
        }

        public async Task<Product[]> Get(int userId)
        {
            var products = await _productRepository.Get(userId);

            if (products == null)
            {
                throw new ArgumentException(nameof(products));
            }

            return products;
        }

        public async Task<Product> GetByProductName(string productName, int userId)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            var product = await _productRepository.GetByName(productName, userId);

            if (product == null)
            {
                throw new ArgumentException(nameof(product));
            }

            return product;
        }

        public async Task<Product[]> GetByOrders(int[] ordersId)
        {
            if (ordersId == null)
            {
                throw new ArgumentException(nameof(ordersId));
            }

            return await _productRepository.GetByOrders(ordersId);
        }
    }
}
