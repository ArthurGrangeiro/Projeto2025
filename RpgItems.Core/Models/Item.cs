using System;
using System.ComponentModel.DataAnnotations;

namespace RpgItems.Core.Models
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    public class Item
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Rarity Rarity { get; set; }

        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
