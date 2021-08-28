using System.Collections.Generic;

namespace API_FlowersStore.DataAccess.MSSQL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Supply> Supplies { get; set; }
    }
}