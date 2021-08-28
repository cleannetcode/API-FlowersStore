﻿namespace API_FlowersStore.Core.CoreModels
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public byte[] Image { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public float Price { get; set; }

        public Category Category { get; set; }
    }
}