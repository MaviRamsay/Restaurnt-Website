using System.Collections.Generic;

namespace Restaurant_Website.Models.Menu
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ImageId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
