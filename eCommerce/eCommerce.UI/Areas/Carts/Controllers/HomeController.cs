using eCommerce.Dal;
using eCommerce.Models;
using eCommerce_.Dal;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerce.UI.Areas.Carts.Controllers
{
    //url: /Carts/Home/MyCarts
    [Area("Carts")]
    public class HomeController : Controller
    {
        private readonly INewCartRepository _newCartRepository;
        private readonly ICommonRepository<CartDetail> _cartDetailRepository;
        private readonly StripeSettings _stripeSettings;
        public string sessionId { get; set; }

        public IActionResult Index()
        {
            return View();
        }
        
        public HomeController(INewCartRepository newCartRepository, ICommonRepository<CartDetail> cartDetailRepository, IOptions<StripeSettings> stripeSettings)
        {
            _newCartRepository = newCartRepository;
            _cartDetailRepository = cartDetailRepository;
            _stripeSettings = stripeSettings.Value;
        }


        // GET: /<controller>/
        public async Task<IActionResult> MyCart()
        {

            var myCartItems = await _newCartRepository.GetCartItems((int)HttpContext.Session.GetInt32("CartId"));
            return View(myCartItems);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            //Please Check do u have customer Id in session...if not redirect the user to login page after successfully login store the customer id into session variable and come back to AddToCart action method once again
            HttpContext.Session.SetInt32("CustomerId", 1);

            if (HttpContext.Session.GetInt32("CartId") == null)
            {
                int cartId = await _newCartRepository.GenerateNewCart
                    ((int)HttpContext.Session.GetInt32("CustomerId"));
                HttpContext.Session.SetInt32("CartId", cartId);
            }




            await _cartDetailRepository.InsertAsync(new()
            {

                CartId = (int)HttpContext.Session.GetInt32("CartId"),
                ProductId = id

            });

            return RedirectToAction("MyCart");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _cartDetailRepository.DeleteAsync(id);
            return RedirectToAction("MyCart");
        }
        public async Task<IActionResult> CreateCheckoutSessionAsync(string amount)
        {
            var myCartItems = await _newCartRepository.GetCartItems((int)HttpContext.Session.GetInt32("CartId"));

            var currency = "inr"; // Currency code

            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
            var options = new SessionCreateOptions
            {
                LineItems = myCartItems.Select(item => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.TotalAmount * 100),
                        Currency = currency, // Change this to your currency
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.ProductName,
                        },
                    },
                    Quantity = 1,
                }).ToList(),
                Mode = "payment",
                SuccessUrl = Url.Action("OrderSuccess", "Home", new { area = "Carts" }, HttpContext.Request.Scheme),
                CancelUrl = Url.Action("OrderCancelled", "Home", new { area = "Carts" }, HttpContext.Request.Scheme),
            };
            var service = new SessionService();
            var session = service.Create(options);
            sessionId = session.Id;
            return Redirect(session.Url);
        }

        public async Task<IActionResult> success()
        {
            // Handle successful payment, e.g., update order status
            return View("Index");
        }

        public IActionResult cancel()
        {
            // Handle cancelled payment, e.g., show a message to the user
            return View("Index");
        }
    }
}