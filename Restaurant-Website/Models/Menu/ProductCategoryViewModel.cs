using Restaurant_Website.Domain.Core;
using System.Collections.Generic;

namespace Restaurant_Website.Models.Menu
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UploadedFile Image { get; set; }
        //public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
