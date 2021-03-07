using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Website.Domain.Core
{
    public class VacancyLang
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public int? VacancyId { get; set; }
        [ForeignKey(nameof(VacancyId))]
        public virtual Vacancy Vacancy { get; set; }
        public string VacancyName { get; set; }
    }
}
