using System.ComponentModel.DataAnnotations;
using RpgItems.Core.Models;

namespace RpgItems.Api.DTOs
{
    public class ItemCreateDto
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Rarity Rarity { get; set; }

        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }
    }

    public class ItemUpdateDto
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Rarity Rarity { get; set; }

        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }
    }
}
