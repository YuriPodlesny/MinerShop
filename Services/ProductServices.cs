using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinerShop.Models;
using MinerShop.Models.Data;
using MinerShop.Models.Orders;
using MinerShop.Models.ViewsModels;

namespace MinerShop.Services
{
    public class ProductServices : IProductServices
    {
        private ShopDbContext db;

        public ProductServices(ShopDbContext dbContext)
        {
            db = dbContext;
        }
        public Product[] GetAllProducts()
        {
            return db.Products.ToArray();
        }

        public Product[] GetProductsByCategoryId(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToArray();
        }

        public Product GetProductById(int id)
        {
            return db.Products.FirstOrDefault(x => x.Id == id);
        }

        public Category[] GetAllCategories()
        {
            return db.Categories.ToArray();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Order[] GetAllOrders()
        {
            return db.Orders.ToArray();
        }

        public bool AddProduct(Product newProduct)
        {
            db.Products.Add(newProduct);
            db.SaveChanges();
            return true;
        }

        public bool AddCategory(Category newCategory)
        {
            db.Categories.Add(newCategory);
            db.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product updateProduct)
        {
            db.Products.Update(updateProduct);
            db.SaveChanges();
            return true;
        }

        public bool UpdateCategory(Category updateCategory)
        {
            db.Categories.Update(updateCategory);
            db.SaveChanges();
            return true;
        }

        public bool DeliteProduct(int productId)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == productId);
            db.Remove(product);
            db.SaveChanges();
            return true;
        }

        public ProductAdminViewModel SelectorProducts(int? category)
        {
            IQueryable<Product> products = db.Products.Include(x => x.Category);
            if (category != null && category != 0)
            {
                products = products.Where(x => x.CategoryId == category);
            }

            List<Category> categories = db.Categories.ToList();
            categories.Insert(0, new Category { Name = "Все", Id = 0 });

            ProductAdminViewModel productAdminViewModel = new ProductAdminViewModel
            {
                Products = products.ToList(),
                CategorieSelectList = new SelectList(categories, "Id", "Name"),
                Categories = db.Categories.ToArray()
            };
            return productAdminViewModel;
        }

    }
}