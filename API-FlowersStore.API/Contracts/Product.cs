using API_FlowersStore.Core.CoreModels;
using System.Collections.Generic;

namespace API_FlowersStore.API.Contracts
{
    public class Product
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Supply> Supplies { get; set; }

        public User User { get; set; }
    }
}