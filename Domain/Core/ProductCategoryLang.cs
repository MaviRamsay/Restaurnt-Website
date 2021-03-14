namespace Restaurant_Website.Domain.Core
{
    public class ProductCategoryLang
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Language Language { get; set; }
        public ProductCategory Category { get; set; }
    }
}
