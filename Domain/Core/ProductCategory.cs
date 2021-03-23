using System.Collections.Generic;

namespace Restaurant_Website.Domain.Core
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public int? ImageId { get; set; }
        public UploadedFile Image { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<ProductCategoryLang> Translations { get; set; }
    }
}
