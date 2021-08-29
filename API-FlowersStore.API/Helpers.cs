using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_FlowersStore.API
{
    public static class Helpers
    {
        public static int GetUser(ControllerBase controllerBase)
        {
            var claimsUserId = controllerBase.User?.Claims.Where(c => c.Type == "UserId").FirstOrDefault();
            var userId = Int32.Parse(claimsUserId.Value);
            return userId;
        }
    }
}
