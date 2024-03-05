using eCommerce.Dal;
using eCommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Areas.Categories.Controllers
{
    [Area("Categories")]
    public class HomeController : Controller
    {
        private readonly ICommonRepository<Category> _categoryRepository;

        public HomeController(ICommonRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryRepository.InsertAsync(category); ;
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
