using System;

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
    }
}
