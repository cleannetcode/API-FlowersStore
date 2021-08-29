using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FlowersStore.API
{
    public static class Helpers
    {
        public static int GetUser(ControllerBase controllerBase)
        {
            var claimsUserId = controllerBase.User?.Claims.Where(c => c.Type == "UserId").FirstOrDefault();
            int userId = Int32.Parse(claimsUserId.Value);
            return userId;
        }
    }
}
