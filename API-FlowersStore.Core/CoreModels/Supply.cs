using System;

namespace API_FlowersStore.Core.CoreModels
{
    public class Supply
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        //public string SupplyService { get; set; }

        //public List<string> SupplyServices { get; set; }
    }
}