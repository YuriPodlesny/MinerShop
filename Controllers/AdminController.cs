using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinerShop.Models;
using MinerShop.Models.Data;
using Microsoft.EntityFrameworkCore;
using MinerShop.Models.Orders;
using MinerShop.Models.ViewsModels;

namespace MinerShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IAllOrders _allOrders;

        public AdminController(IProductServices productServices, IAllOrders allOrders)
        {
            _productServices = productServices;
            _allOrders = allOrders;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Products(int category)
        {
            ProductAdminViewModel productViewModel = _productServices.SelectorProducts(category);
            return View(productViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Categories()
        {
            return View(_productServices.GetAllCategories());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Orders()
        {
            return View(_productServices.GetAllOrders());
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddProduct()
        {
            //ViewBag.Categories = _productServices.GetAllCategories();
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {

                var result = _productServices.AddProduct(newProduct);
                if (result)
                {
                    return RedirectToAction("Products");
                }

                return Content("Продукт не добавлен");
            }

            return View(newProduct);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                var result = _productServices.AddCategory(newCategory);
                if (result)
                {
                    return RedirectToAction("Categories");
                }

                return Content("Категория не добавлена");
            }

            return View(newCategory);
        }

        [Authorize]
        [HttpGet]
        [ActionName("DeliteProduct")]
        public IActionResult ConfirmDeliteProduct(int productId)
        {
            Product product = _productServices.GetProductById(productId);
            return View(product);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeliteProduct(int productId)
        {
            _productServices.DeliteProduct(productId);
            return RedirectToAction(nameof(Products));
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            Product product = _productServices.GetProductById(productId);
            return View(product);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditProduct(Product editProduct)
        {
            if (ModelState.IsValid)
            {

                var result = _productServices.UpdateProduct(editProduct);
                if (result)
                {
                    return RedirectToAction(nameof(Products));
                }

                return Content("Продукт не изменен");
            }

            return View(editProduct);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditCategory(int categoryId)
        {
            Category category = _productServices.GetCategoryById(categoryId);
            return View(category);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditCategory(Category editCategory)
        {
            if (ModelState.IsValid)
            {

                var result = _productServices.UpdateCategory(editCategory);
                if (result)
                {
                    return RedirectToAction(nameof(Categories));
                }

                return Content("Продукт не изменен");
            }

            return View(editCategory);
        }

        [Authorize]
        [HttpGet]
        public IActionResult DetailProduct(int productId)
        {
            Product product = _productServices.GetProductById(productId);
            return View(product);
        }

        [Authorize]
        [HttpGet]
        public IActionResult DetailCategory(int categoryId)
        {
            Category category = _productServices.GetCategoryById(categoryId);
            return View(category);
        }

        [HttpGet]
        public IActionResult OrderDetails(int orderId)
        {
            return View(_allOrders.GetOrderDetailJoinProductByOrderId(orderId));
        }

    }
}