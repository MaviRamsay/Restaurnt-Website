using System;

namespace Restaurant_Website.Domain.Core
{
    public class Language
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string AvalibleCountries { get; set; }
    }
}
