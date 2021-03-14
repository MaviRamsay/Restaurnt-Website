using System.Collections.Generic;

namespace Restaurant_Website.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public UploadedFile Image { get; set; }

        public ICollection<ProductLang> Translations { get; set; }

    }
}
