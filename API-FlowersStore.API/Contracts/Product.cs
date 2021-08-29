﻿namespace API_FlowersStore.API.Contracts
{
    public class ProductResponse
    {
        public string ProviderName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}