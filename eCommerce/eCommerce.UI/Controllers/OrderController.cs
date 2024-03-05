using eCommerce.UI.Models;
using Razorpay.Api;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;

namespace eCommerce.UI.Controllers
{
    public class OrderController : Controller
    {
        [BindProperty]
        public OrderEntity _OrderDetails {  get; set; }
        /*public MyCartVM _CartVM { get; set; }*/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InitiateOrder()
        {
            string key = "rzp_test_fWb1TIgierVcaj";
            string secret = "RvKhE9Wr7HynfPiLqc5iB8fM";

            Random rnd = new Random();
            string TransactionId = rnd.Next(0,10000).ToString();

            /*yCartVM _CartVM = new MyCartVM();

            _OrderDetails.TotalAmount = _CartVM.DiscountedAmount;*/

            Dictionary<string,object> input = new Dictionary<string,object>();
            input.Add("amount", Convert.ToDecimal(_OrderDetails.TotalAmount)*100);
            input.Add("currency", "INR");
            /*input.Add("recipt", TransactionId);*/

            RazorpayClient client = new RazorpayClient(key, secret);
            Razorpay.Api.Order order = client.Order.Create(input);

            ViewBag.orderId = order["id"].ToString();

            return View("Payments",_OrderDetails);
        }
        public IActionResult Payments(string razor_payment_id, string razor_order_id, string razor_signature)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razor_payment_id", razor_payment_id);
            attributes.Add("razor_order_id", razor_order_id);
            attributes.Add("razor_signature", razor_signature);

            Utils.verifyPaymentLinkSignature(attributes);
            OrderEntity orderdetails = new OrderEntity();

            orderdetails.TransactionId = razor_payment_id;
            orderdetails.OrderId = razor_order_id;

            return View("PaymentSuccess", orderdetails);    
        }
    }
}
