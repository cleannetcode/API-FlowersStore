﻿using System;

namespace API_FlowersStore.API.Contracts
{
    public class NewOrder
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}