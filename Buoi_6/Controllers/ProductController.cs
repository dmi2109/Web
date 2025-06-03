using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Buoi_6.Models;
using Buoi_6.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Buoi_6.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();

            ViewBag.CategoryName = "nổi bật";  // hoặc "Tất cả sản phẩm"
            return View(Tuple.Create(products, categories));
        }



        public async Task<IActionResult> Display(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        public async Task<IActionResult> ByCategory(int categoryId)
        {
            var products = await _productRepository.GetByCategoryIdAsync(categoryId);
            var categories = await _categoryRepository.GetAllAsync();

            var category = await _categoryRepository.GetByIdAsync(categoryId);
            ViewBag.CategoryName = category?.Name ?? "Danh mục";

            return View("Index", Tuple.Create(products, categories));
        }



    }
}
