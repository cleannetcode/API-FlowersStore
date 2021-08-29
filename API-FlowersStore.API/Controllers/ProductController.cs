using API_FlowersStore.API.Contracts;
using API_FlowersStore.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API_FlowersStore.API.Controllers
{
    /// <summary>
    /// Контроллер продукта
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatedProduct), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProduct(NewProduct request)
        {
            var newProduct = _mapper.Map<NewProduct, Core.CoreModels.Product>(request);

            var productName = await _productService.Create(newProduct);

            return Ok(new CreatedProduct { Name = productName });
        }

        [HttpGet]
        [ProducesResponseType(typeof(Core.CoreModels.Product[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
           var products = await _productService.Get();

            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return Ok(products);
        }

        [HttpPost("{update}")]
        [ProducesResponseType(typeof(CreatedProduct), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct(NewProduct request)
        {
            var newProduct = _mapper.Map<NewProduct, Core.CoreModels.Product>(request);

            var productName = await _productService.Update(newProduct);

            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            return Ok(new UpdatedProduct { Name = productName });
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string ProductName)
        {
            if (string.IsNullOrEmpty(ProductName))
            {
                throw new ArgumentException(nameof(ProductName));
            }

            var result = await _productService.Delete(ProductName);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
