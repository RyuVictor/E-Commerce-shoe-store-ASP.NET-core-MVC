namespace eCommerce.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CartDate { get; set; }
        public ICollection<CartDetail>? CartDetails { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }

    }   
}
