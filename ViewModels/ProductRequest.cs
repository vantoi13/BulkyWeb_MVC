using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BulkyWeb.ViewModels
{
    public class ProductRequest
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Display(Name = "Description")]

        [Required]
        public string? Description { get; set; }
        [Display(Name = "ISBN")]
        [Required]
        public string? ISBN { get; set; }
        [Display(Name = "Author")]
        [Required]
        public string? Author { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Image")]    
        public IFormFile? Image { get; set; } // Dành cho file ảnh nếu cần
    }
}
