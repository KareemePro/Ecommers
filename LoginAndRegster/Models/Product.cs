using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndRegster.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [MinLength(5)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        [MaxLength(20)]
        [MinLength(3)]
        [Display(Name = "Product colore")]
        public string ProductColor { get; set; } = string.Empty;
        [MaxLength(200)]
        [MinLength(5)]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        [NotMapped]
        public string CategoryName { get; set; } = string.Empty;
    }
}
