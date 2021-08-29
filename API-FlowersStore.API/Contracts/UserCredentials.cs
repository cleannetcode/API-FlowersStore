using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FlowersStore.API.Contracts
{
    /// <summary>
    /// Учетные данные пользователя системы (поставщик, админ и т.д. ).
    /// </summary>
    public class UserCredentials

    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
