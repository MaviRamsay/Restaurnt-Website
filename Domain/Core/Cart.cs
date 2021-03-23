using System;

namespace Restaurant_Website.Domain.Core
{
    public class Cart
    {
        public int Id { get; set; }

        public AppUser User { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
