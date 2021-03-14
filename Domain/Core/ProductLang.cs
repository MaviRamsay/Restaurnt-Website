namespace Restaurant_Website.Domain.Core
{
    public class ProductLang
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }
        public Product Product { get; set; }
    }
}
