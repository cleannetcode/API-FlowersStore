using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FlowersStore.API.Contracts
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Role { get; set; }

        //public ICollection<Supply> Supplies { get; set; }

        //public ICollection<Order> Orders { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
