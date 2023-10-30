using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LoginAndRegster.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
