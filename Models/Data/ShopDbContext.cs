using Microsoft.EntityFrameworkCore;
using MinerShop.Models.Cart;
using MinerShop.Models.Orders;


namespace MinerShop.Models.Data
{
    public sealed class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}