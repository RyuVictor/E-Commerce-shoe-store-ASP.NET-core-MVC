using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public string TransactionId { get; set; }= string.Empty;
        public decimal TotalAmount;
    }
}
