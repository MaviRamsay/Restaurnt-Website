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

        public async Task<bool> CreateVacancyAsync(Vacancy vacancy)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> EditVacancyAsync(Vacancy vacancy)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteVacancy(Vacancy vacancy)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<VacancyLang>> GetVacancyTranslationsAsync(string lang)
        {
            return await unitOfWork.VacancyTranslations.GetAllAsync(t => t.Vacancy.IsActive == true && t.Language.Code == lang);
        }

        public async Task<Vacancy> GetVacancyByIdAsync(int id)
        {
            return await unitOfWork.Vacancies.GetAsync(t => t.Id == id);
        }

        public async Task<byte[]> ConvertCvToArrayAsync(IFormFile file)
        {
            byte[] cv;
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                cv = ms.ToArray();
            }

            return cv;
        }
    }
}
