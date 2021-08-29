﻿using System;
using System.Collections.Generic;

namespace API_FlowersStore.DataAccess.MSSQL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Quantity { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        //public string UserService { get; set; }

        //public List<UserService> UserServices { get; set; }
    }
}