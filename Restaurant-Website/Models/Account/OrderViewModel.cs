using Restaurant_Website.Models.Menu;
using System;

namespace Restaurant_Website.Models.Account
{
    public class OrderViewModel
    {
        public ProductViewModel Product { get; set; }
        public DateTime Date { get; set; }
        public bool PaymentType { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }
    }
}
