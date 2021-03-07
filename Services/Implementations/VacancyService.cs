using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Implementations
{
    public class VacancyService : IVacancyService
    {
        private readonly IUnitOfWork unitOfWork;

        public VacancyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(Vacancy vacancy)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> EditAsync(Vacancy vacancy)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Vacancy vacancy)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<VacancyLang>> GetTranslationsAsync(string lang)
        {
            return await unitOfWork.VacancyTranslations.GetAllAsync(t => t.Vacancy.IsActive == true && t.Language.Code == lang, includeProperties: "Vacancy");
        }

        public async Task<Vacancy> GetByIdAsync(int id)
        {
            return await unitOfWork.Vacancies.GetAsync(t => t.Id == id);
        }
    }
}
