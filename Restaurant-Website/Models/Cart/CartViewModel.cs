using Restaurant_Website.Models.Menu;

namespace Restaurant_Website.Models.Cart
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
    }
}
