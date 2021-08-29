namespace API_FlowersStore.API.Contracts
{
    public class OrderProduct
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}