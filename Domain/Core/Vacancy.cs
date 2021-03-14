using System.Collections.Generic;

namespace Restaurant_Website.Domain.Core
{
    public class Vacancy
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public ICollection<VacancyLang> Translations { get; set; }
    }
}
