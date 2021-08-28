using System.Collections.Generic;

namespace API_FlowersStore.Core.CoreModels
{
    public class Order
    {
        public int Id { get; set; }

        public List<int> ProviderId { get; set; }

        public List<int> ProductId { get; set; }

        public List<string> UserServices { get; set; }
    }
}
