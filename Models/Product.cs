using System.ComponentModel.DataAnnotations;

namespace jewllery_keep.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        public double Price { get; set; }

        [Required]
        public required string ImageUrl { get; set; }

        public int Stock { get; set; }
    }
}