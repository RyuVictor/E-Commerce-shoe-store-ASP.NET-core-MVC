using Microsoft.AspNetCore.Mvc;
using eCommerce.Dal;
using eCommerce.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Diagnostics;

namespace eCommerce.UI.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        private readonly ICommonRepository<Product> _productRepo;
        private readonly IMemoryCache _productsCache;

        public HomeController(ICommonRepository<Product> productRepo, IMemoryCache productCache)
        {
            _productRepo = productRepo;
            _productsCache = productCache;
        }


        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllAsync();
            ViewBag.PageTitle = "eCommerce Products List";
            ViewBag.PageSubTitle = "Find all products under single roof";
            if (_productsCache.TryGetValue("eCommerceProductsCache", out List<Product> _products))
            {
                return View(_products);
            }
            var allProducts = await _productRepo.GetAllAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(new TimeSpan(0, 10, 0))
                .SetSlidingExpiration(new TimeSpan(0, 1, 0));

            _productsCache.Set("eCommerceProductsCache", allProducts, cacheEntryOptions);
            return View(allProducts);
        }
        public async Task<ActionResult> Details(int id)
        {
            ViewBag.PageTitle = "Details of - ";
            var product = await _productRepo.GetDetailAsync(id);
            double discountedAmount = product.UnitPrice - ((product.UnitPrice * product.Discount) / 100);
            ViewBag.Discount = discountedAmount;
            return View(product);
        }
        public async Task<ActionResult> GetParticularCategoryProducts(int id)
        {
            ViewBag.PageTitle = "eCommerce Products List";
            ViewBag.PageSubTitle = "Find all products under single roof using Category ID";
            var products = await _productRepo.GetAllAsync();
            List<Product> categoryProducts = new List<Product>();
            foreach (var product in products)
            {
                if(product.CategoryId == id)
                {
                    categoryProducts.Add(product);
                }

            }
            return View(categoryProducts);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productRepo.InsertAsync(product); ;
                if (result > 0)
                {
                    RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}