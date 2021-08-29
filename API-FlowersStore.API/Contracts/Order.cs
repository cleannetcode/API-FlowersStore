using System;

namespace API_FlowersStore.API.Contracts
{
    public class Order
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Quantity { get; set; }

    }
}