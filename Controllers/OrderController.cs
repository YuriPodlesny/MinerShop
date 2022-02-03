using Microsoft.AspNetCore.Mvc;
using MinerShop.Models;
using MinerShop.Models.Cart;
using MinerShop.Models.Orders;

namespace MinerShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;
            _shopCart = shopCart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopCartItems();

            if (_shopCart.ListShopItems.Count==0)
            {
                ModelState.AddModelError("","Корзина пуста");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction(nameof(Complete));
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ принят, в ближайшее время с вами свяжется оператор";
            return View();
        }
    }
}