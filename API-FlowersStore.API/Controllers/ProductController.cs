using API_FlowersStore.API.Contracts;
using API_FlowersStore.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        private readonly IUserService _userService;

        public ProductController(
            IProductService productService,
            IMapper mapper,
            IUserService userService)
        {
            _productService = productService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatedProduct), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProduct(NewProduct request)
        {
            request.UserId = GetUser();

            var newProduct = _mapper.Map<NewProduct, Core.CoreModels.Product>(request);

            var productName = await _productService.Create(newProduct);

            return Ok(new CreatedProduct { Name = productName });
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductResponse[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var userId = GetUser();

            var products = await _productService.Get(userId);

            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return Ok(products.Select(f => new ProductResponse()
            {
                Name = f.Name,
                Amount = f.Amount,
                Color = f.Color,
                Description = f.Description,
                Price = f.Price,
                ProviderName = _userService.GetById(f.UserId).Result.Name
            }));
        }

        [HttpPost("{update}")]
        [ProducesResponseType(typeof(CreatedProduct), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct(NewProduct request)
        {
            request.UserId = GetUser();

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
            var userId = GetUser();

            if (string.IsNullOrEmpty(ProductName))
            {
                throw new ArgumentException(nameof(ProductName));
            }

            var result = await _productService.Delete(ProductName, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [NonAction]
        private int GetUser()
        {
            var userId = Helpers.GetUser(this);

            if (userId <= default(int))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return userId;
        }
    }
}
