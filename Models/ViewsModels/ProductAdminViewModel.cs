using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MinerShop.Models.ViewsModels
{
    public class ProductAdminViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public SelectList CategorieSelectList { get; set; }
    }
}