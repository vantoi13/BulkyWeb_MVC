using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.ViewModels
{
    public class CategoryRequest
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string? Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100)]
        [Required]
        public int? DisplayOrder { get; set; }

        public ICollection<ProductViewModel>? Products { get; set; }
    }
}