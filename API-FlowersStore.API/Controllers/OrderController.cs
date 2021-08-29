using API_FlowersStore.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public OrderController()
        {

        }

        //public async Task<IActionResult> CreateOrder(NewOrder[] request)
        //{
        //    // 1 response order with total price
        //}

        //public async Task<IActionResult> GetOrders()
        //{
        //    // array response orders

        //}

        //public async Task<IActionResult> GetProducts()
        //{

        //}

        //public async Task<IActionResult> GetProductByProvider()
        //{

        //}
    }
}
