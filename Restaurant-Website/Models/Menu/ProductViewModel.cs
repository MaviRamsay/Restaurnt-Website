using Restaurant_Website.Domain.Core;

namespace Restaurant_Website.Models.Menu
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; } = 1;
        public UploadedFile Image { get; set; }
    }
}
