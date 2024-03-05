namespace eCommerce.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CartId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
