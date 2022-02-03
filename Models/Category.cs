using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace MinerShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Img { get; set; }
        public string Description { get; set; }

    }
}