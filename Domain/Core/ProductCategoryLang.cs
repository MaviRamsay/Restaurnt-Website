namespace Restaurant_Website.Domain.Core
{
    public class ProductCategoryLang
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? LanguageId { get; set; }
        public Language Language { get; set; }
        public int? CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}
