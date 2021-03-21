using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace Restaurant_Website.Services.Implementations
{
    public class VacancyService : IVacancyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Func<IQueryable<Vacancy>, IIncludableQueryable<Vacancy, object>> include;

        public VacancyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.include = t => t.Include(t => t.Translations)
                                    .ThenInclude(t => t.Language);
        }

        public async Task<bool> CreateAsync(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditAsync(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vacancy>> GetAllAsync(bool onlyActive)
        {
            Expression<Func<Vacancy, bool>> predicate = t => t.IsActive;
            return await unitOfWork.Vacancies.GetAllAsync(onlyActive ? predicate : null,  include: include);
        }

        public async Task<IEnumerable<VacancyLang>> GetTranslationsAsync(string lang)
        {
            var all = await GetAllAsync(true);
            return all.Select(t => t.Translations).Select(t => t.FirstOrDefault(t => t.Language.Code == lang));
        }

        public async Task<Vacancy> GetByIdAsync(int id)
        {
            return await unitOfWork.Vacancies.GetAsync(t => t.Id == id, include);
        }
    }
}

