using MinerShop.Models.Orders;
using MinerShop.Models.ViewsModels;

namespace MinerShop.Models
{
    public interface IProductServices
    {
        Product [] GetAllProducts();
        Product[] GetProductsByCategoryId(int categoryId);
        Product GetProductById(int id);

        Category[] GetAllCategories();
        Category GetCategoryById(int id);

        Order[] GetAllOrders();

        bool AddProduct(Product newProduct);
        bool AddCategory(Category newCategory);

        bool UpdateProduct(Product updateProduct);
        bool UpdateCategory(Category updateCategory);

        bool DeliteProduct(int deliteProduct);

        public ProductAdminViewModel SelectorProducts(int? category);

    }
}