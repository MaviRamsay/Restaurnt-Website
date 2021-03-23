namespace Restaurant_Website.Domain.Core
{
    public class ProductLang
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? LanguageId { get; set; } 
        public Language Language { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
