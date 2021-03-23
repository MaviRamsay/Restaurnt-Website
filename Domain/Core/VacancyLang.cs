namespace Restaurant_Website.Domain.Core
{
    public class VacancyLang
    {
        public int Id { get; set; }

        public int? LanguageId { get; set; }
        public Language Language { get; set; }
        public int? VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public string VacancyName { get; set; }
    }
}
