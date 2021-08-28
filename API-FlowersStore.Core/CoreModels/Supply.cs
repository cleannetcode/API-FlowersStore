using System.Collections.Generic;

namespace API_FlowersStore.Core.CoreModels
{
    public class Supply
    {
        public int Id { get; set; }

        public List<int> ProviderId { get; set; }

        public List<int> ProductId { get; set; }

        public List<string> SupplyServices { get; set; }

        public Category Category { get; set; }

        public Provider Provider { get; set; }
    }
}