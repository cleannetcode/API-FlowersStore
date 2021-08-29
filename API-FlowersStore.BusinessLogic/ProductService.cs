using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Repositories;
using API_FlowersStore.Core.Services;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace API_FlowersStore.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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

        public async Task<bool> Delete(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            return await _productRepository.Delete(productName);
        }

        public async Task<Product[]> Get()
        {
            var products = await _productRepository.Get();

            if (products == null)
            {
                throw new ArgumentException(nameof(products));
            }

            return products;
        }
    }
}
