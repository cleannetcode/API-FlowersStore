using API_FlowersStore.API.Contracts;
using API_FlowersStore.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API_FlowersStore.API.Controllers
{
    /// <summary>
    /// Контроллер заказа
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderService orderService,
            IUserService userService,
            IProductService productService,
            IMapper mapper)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("CreateOrder")]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrder(NewOrder[] request)
        {
            var userId = GetUser();

            var customer = await _userService.GetById(userId);

            var orderList = new List<Core.CoreModels.Order>(request.Length);

            var productList = new List<Core.CoreModels.Product>(request.Length);

            var currentTime = DateTime.Now;

            foreach (var f in request)
            {
                var providerUser = _userService.GetByUserName(f.ProviderName).Result;

                if (providerUser == null)
                {
                    return BadRequest("Provider name is invalid");
                }

                var product = _productService.GetByProductName(f.ProductName, providerUser.Id).Result;

                if (product == null)
                {
                    return BadRequest("Product not found");
                }

                orderList.Add(new Core.CoreModels.Order()
                {
                    UserId = userId,
                    ProductId = product.Id,
                    CreatedDate = currentTime,
                    Quantity = f.Quantity.Value
                });

                productList.Add(product);
            }

            var result = await _orderService.Create(orderList);

            if (!result)
            {
                return BadRequest();
            }

            var orderProducts = productList.Select(f => new OrderProduct()
            {
                Name = f.Name,
                Description = f.Description,
                Color = f.Color,
                Price = f.Price,
                Quantity = request.FirstOrDefault(
                        x => x.ProductName == f.Name && _userService.GetById(f.UserId).Result.Name == x.ProviderName).Quantity.Value
            }).ToArray();

            foreach (var f in orderProducts)
            {
                f.TotalPrice = (decimal)f.Quantity * f.Price;
            }

            var orderResponse = new OrderResponse()
            {
                UserName = customer.Name,
                CreatedDate = currentTime,
                OrderProducts = orderProducts,
                TotalPrice = orderProducts.Sum(f => f.TotalPrice)
            };

            return Ok(orderResponse);
        }

        [HttpGet("GetOrders")]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrders()
        {
            var userId = GetUser();

            var customer = await _userService.GetById(userId);

            var orderCollection = _orderService.GetByUserId(userId).Result
                .GroupBy(x => x.CreatedDate)
                .ToDictionary(g => g.Key, g => g.ToArray());

            var response = new List<OrderResponse>(orderCollection.Keys.Count);

            foreach (var f in orderCollection)
            {
                var products = await _productService.GetByOrders(f.Value.Select(ff => ff.Id).ToArray());

                var orderProducts = f.Value.Select(ff => new OrderProduct()
                {
                    Name = products.FirstOrDefault(fff => fff.Id == ff.ProductId).Name,
                    Description = products.FirstOrDefault(fff => fff.Id == ff.ProductId).Description,
                    Color = products.FirstOrDefault(fff => fff.Id == ff.ProductId).Color,
                    Price = products.FirstOrDefault(fff => fff.Id == ff.ProductId).Price,
                    Quantity = ff.Quantity
                }).ToArray();

                foreach (var o in orderProducts)
                {
                    o.TotalPrice = ((decimal)o.Quantity) * (decimal)o.Price;
                }

                response.Add(new OrderResponse()
                {
                    UserName = customer.Name,
                    CreatedDate = f.Key,
                    OrderProducts = orderProducts,
                    TotalPrice = orderProducts.Sum(f => f.TotalPrice)
                });
            }

            return Ok(response);
        }

        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(ProductResponse[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _orderService.GetProducts();

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

        [HttpGet("GetProductByProvider")]
        [ProducesResponseType(typeof(ProductResponse[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByProvider()
        {
            var userId = Helpers.GetUser(this);

            if (userId <= default(int))
            {
                throw new ArgumentNullException(nameof(userId));
            }
            var user = await _userService.GetById(userId);

            var products = await _orderService.GetProductsByUserId(userId);

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
                ProviderName = user.Name
            }));
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
