using eCommerce.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.UI.Models
{
    public class OrderEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public double TotalAmount { get; set; }
        /*public double DiscountedAmount { get; set; }*/
        public string TransactionId { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
    }
}
