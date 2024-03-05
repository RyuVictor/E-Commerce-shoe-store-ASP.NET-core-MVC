namespace eCommerce.Models
{
    public class MyCartVM
    {
        public string? Picture { get; set; }
        public int CartDetailId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double UnitPrice { get; set; }
        public int Size { get; set; }
        public int Discount { get; set; }
        public double DiscountedAmount { get; set; }
        public int Quantity { get; set; }
        public DateTime CartDate { get; set; }
        public decimal TotalAmount => (decimal)(Quantity * DiscountedAmount);
    }
}
