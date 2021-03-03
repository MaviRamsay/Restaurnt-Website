using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;

namespace Restaurant_Website.Services.Interfaces
{
    public interface IVacancyService
    {
        Task<IEnumerable<VacancyLang>> GetVacancyTranslationsAsync(string lang);
        Task<Vacancy> GetVacancyByIdAsync(int id);

        Task<bool> CreateVacancyAsync(Vacancy vacancy);
        Task<bool> EditVacancyAsync(Vacancy vacancy);
        bool DeleteVacancy(Vacancy vacancy);
    }
}
