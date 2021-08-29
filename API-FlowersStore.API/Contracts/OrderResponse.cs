using System;
using System.Collections.Generic;

namespace API_FlowersStore.API.Contracts
{
    public class OrderResponse
    {
        public string UserName { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}