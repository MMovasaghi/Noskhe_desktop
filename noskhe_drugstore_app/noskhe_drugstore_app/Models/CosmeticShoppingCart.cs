namespace noskhe_drugstore_app.Models
{
    public class CosmeticShoppingCart
    {
        public int CosmeticId { get; set; }
        public Cosmetic Cosmetic { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}