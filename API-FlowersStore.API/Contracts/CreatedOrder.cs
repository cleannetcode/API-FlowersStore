using System.Collections.Generic;

namespace API_FlowersStore.API.Contracts
{
    public class CreatedOrder
    {
        public int UserName { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public string ProductColor { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
