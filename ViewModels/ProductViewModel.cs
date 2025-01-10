using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWeb.ViewModels
{
    public class ProductViewModel
    {   
        [Key]
        public int Id { get; set; }
        [Display(Name ="Title")]
        public string? Title { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "ISBN")]

        public string? ISBN { get; set; }
        [Display(Name = "Author")]
        public string? Author { get; set; }
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Price for 50+")]
        public double Price50 { get; set; }
        [Display(Name = "Price for 100+")]
        public double Price100 { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string? CategoryName { get; set; } // Ánh xạ từ Category
        [Display(Name = "Image")]
        public string? ImagePath { get; set; } // Đường dẫn ảnh
    }
}
