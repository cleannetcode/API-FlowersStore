using API_FlowersStore.API.Contracts;
using API_FlowersStore.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(CreatedOrder), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> CreateOrder(NewOrder[] request)
        //{
        //    // 1 response order with total price
        //}

        //public async Task<IActionResult> GetOrders()
        //{
        //    // array response orders


        //}

        [HttpGet]
        [ProducesResponseType(typeof(Core.CoreModels.Product[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _orderService.Get();

            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return Ok(products);
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(Core.CoreModels.Product[]), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> GetProductByProvider()
        //{
        //    //var user = await userService.Get();

        //    //if (user == null)
        //    //{
        //    //    throw new ArgumentNullException(nameof(user));
        //    //}

        //    var products = await _orderService.GetByProvider(user);

        //    if (products == null)
        //    {
        //        throw new ArgumentNullException(nameof(products));
        //    }

        //    return Ok(products);
        //}
    }
}
