using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MinerShop.Models;
using MinerShop.Models.Cart;
using MinerShop.Models.Data;
using MinerShop.Models.Orders;

namespace MinerShop.Services
{
    public class OrderServices : IAllOrders
    {
        private readonly ShopDbContext _shopDbContext;
        private readonly ShopCart _shopCart;

        public OrderServices(ShopDbContext shopDbContext, ShopCart shopCart)
        {
            _shopDbContext = shopDbContext;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _shopDbContext.Orders.Add(order);
            _shopDbContext.SaveChanges();

            var items = _shopCart.ListShopItems;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };
                _shopDbContext.OrderDetails.Add(orderDetail);
            }

            _shopDbContext.SaveChanges();
        }

        public IEnumerable<OrderDetail> GetOrderDetailJoinProductByOrderId(int orderId)
        {
            IEnumerable<OrderDetail> orderDetailsJoinProducts = _shopDbContext.OrderDetails
                .Where(x => x.OrderId == orderId)
                .Include(x => x.Product);
            return orderDetailsJoinProducts;
        }
    }
}