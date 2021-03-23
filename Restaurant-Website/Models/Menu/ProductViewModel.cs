namespace Restaurant_Website.Models.Menu
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }
        public int? CategoryId { get; set; }
    }
}
