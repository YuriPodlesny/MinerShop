namespace MinerShop.Models.Cart
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Namber { get; set; }
        public decimal Price { get; set; }

        public string ShopCartId { get; set; }
    }
}