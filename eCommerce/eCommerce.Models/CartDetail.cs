using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class CartDetail
    {
        public int CartDetailId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public int Size { get; set; } = 7;
        public virtual Cart? Cart { get; set; }
        public virtual Product? Product { get; set; }
    }
}
