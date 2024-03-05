using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is a required field!")]
        [MaxLength(50, ErrorMessage = "Category name can not be more than 50 characters!")]
        public string CategoryName { get; set; } = string.Empty;
        [MaxLength(200, ErrorMessage = "Category description can not be more than 200 characters!")]
        public string? CategoryDescription { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
