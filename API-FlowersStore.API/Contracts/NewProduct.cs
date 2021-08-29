using System.ComponentModel.DataAnnotations;

namespace API_FlowersStore.API.Contracts
{
    public class NewProduct
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Color { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
