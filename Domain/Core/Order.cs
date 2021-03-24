using System;

namespace Restaurant_Website.Domain.Core
{
    public class Order
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
        public bool PaymentType { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }
    }
}
