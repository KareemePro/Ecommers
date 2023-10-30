namespace LoginAndRegster.ViewModel
{
    public class ProductViewModel
    {
        
        [MaxLength(30)]
        [MinLength(5)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; } = Enumerable.Empty<SelectListItem>();


        [Required]
        public decimal Price { get; set; }

        [MaxLength(20)]
        [MinLength(3)]
        [Display(Name = "colore")]
        public string ProductColor { get; set; } = string.Empty;


        [MaxLength(200)]
        [MinLength(5)]
        public string Description { get; set; } = string.Empty;

        
        
    }
}
