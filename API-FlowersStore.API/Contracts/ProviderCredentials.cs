using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FlowersStore.API.Contracts
{
    /// <summary>
    /// Учетные данные поставщика.
    /// </summary>
    public class ProviderCredentials
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
