using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinerShop.Models.Data;

namespace MinerShop.Models.Cart
{
    public class ShopCart
    {
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        private readonly ShopDbContext shopDbContext;
        public ShopCart(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<ShopDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product)
        {
            shopDbContext.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Product = product,
                Namber = product.Number,
                Price = product.Price
            });
            shopDbContext.SaveChanges();
        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return shopDbContext.ShopCartItem.Where(x => x.ShopCartId == ShopCartId).Include(s => s.Product).ToList();
        }
    }
}