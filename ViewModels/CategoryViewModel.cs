using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.ViewModels
{
public class CategoryViewModel{

        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        public string? Name { get; set; }

        [DisplayName("Display Order")]
        public int? DisplayOrder { get; set; }

        public ICollection<ProductViewModel>? Products { get; set; }
    }
}