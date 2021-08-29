using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_FlowersStore.API.Contracts
{
    public class NewProduct
    {
        [JsonIgnore]
        public int UserId { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Color { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public int? Amount { get; set; }
    }
}
