using Microsoft.AspNetCore.Mvc;
using MinerShop.Models;
using MinerShop.Models.Cart;
using MinerShop.Models.ViewsModels;

namespace MinerShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ShopCart _shopCart;

        public CartController(IProductServices productServices, ShopCart shopCart)
        {
            _productServices = productServices;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel { ShopCart = _shopCart };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int productId)
        {
            var item = _productServices.GetProductById(productId);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}