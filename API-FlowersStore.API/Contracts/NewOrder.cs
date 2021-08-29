using System.ComponentModel.DataAnnotations;

namespace API_FlowersStore.API.Contracts
{
    public class NewOrder
    {
        [Required]
        [MaxLength(30)]
        public string ProviderName { get; set; }

        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; }

        [Required]
        public int? Quantity { get; set; }
    }
}