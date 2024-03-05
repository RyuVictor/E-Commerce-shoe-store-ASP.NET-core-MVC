using System.ComponentModel.DataAnnotations;
namespace eCommerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer Name is a required field")]
        [MaxLength(100,ErrorMessage = "Customer Name cannot exceed 100 Characters")]
        public string ContactName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address is a required field")]
        [MaxLength(500,ErrorMessage = "Address cannot exceed 500 Characters")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "City Name is a required field")]
        [MaxLength(100,ErrorMessage = "City Name cannot exceed 100 Characters")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is a required field")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 Characters")]
        [EmailAddress(ErrorMessage ="Please enter valid email Id")]
        public string email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone is a required field")]
        [MaxLength(20, ErrorMessage = "Phone cannot exceed 20 Characters")]
        public string Phone { get; set; } = string.Empty;
        public virtual ICollection<Cart>? Carts { get; set; }
    }
}
