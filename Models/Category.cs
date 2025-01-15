using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string? Name { get; set; }

        [Range(1, 100)]
        public int? DisplayOrder { get; set; }

        // Ánh xạ ngược: Một Category chứa nhiều Products
        public ICollection<Product>? Products { get; set; }
    }
}
