using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required field!")]
        [MaxLength(100, ErrorMessage = "Product name can not exceed 100 characters!")]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product Unit Price is required field!")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Product Description is required field!")]
        [MaxLength(500, ErrorMessage = "Product description can not exceed 500 characters!")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Manufacturing date is required field!")]
        public DateTime ManufacturingDate { get; set; }

        [MaxLength(100, ErrorMessage = "Made In value can not exceed 100 characters!")]
        [Required(ErrorMessage = "Made In is required field!")]
        public string? MadeIn { get; set; }

        [MaxLength(50, ErrorMessage = "Shoe Type can not exceed 50 characters!")]

        [Required(ErrorMessage = "Shoe type is required field!")]
        public string? ShoeType { get; set; }

        [MaxLength(15, ErrorMessage = "Gender can not exceed 15 characters!")]
        [Required(ErrorMessage = "Gender is required field!")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Warranty Period is required field!")]
        [MaxLength(50, ErrorMessage = "Warranty period can not exceed 50 characters!")]
        public string? WarrantyPeriod { get; set; }

        [Required(ErrorMessage = "Return Policy is required field!")]
        [MaxLength(100, ErrorMessage = "Return policy can not exceed 100 characters!")]
        public string? ReturnPolicy { get; set; }

        [Required(ErrorMessage = "Quantity is required field!")]
        public int Quantity { get; set; }
        [Range(0, 70, ErrorMessage = "Discount must be between 0-to-70 Percent!")]
        public int Discount { get; set; }
        [MaxLength(500, ErrorMessage = "Product picture can not exceed 500 characters!")]
        public string? Picture { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
