using Microsoft.AspNetCore.Mvc;
using MinerShop.Models;
using MinerShop.Models.ViewsModels;

namespace MinerShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductServices _productServices;

        public CatalogController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Categories()
        {
            Category[] category = _productServices.GetAllCategories();
            return View(category);
        }

        public IActionResult Category(int categoryId)
        {
            CategoryViewModel category = new CategoryViewModel();
            category.Category = _productServices.GetCategoryById(categoryId);
            category.Products = _productServices.GetProductsByCategoryId(categoryId);
            
            return View(category);
        }

        public IActionResult Product(int productId)
        {
            Product product = _productServices.GetProductById(productId);
            return View(product);
        }
    }
}