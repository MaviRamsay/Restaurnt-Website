using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Func<IQueryable<Application>, IIncludableQueryable<Application, object>> include;


        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.include = inc => inc.Include(entity => entity.Vacancy)
                                        .ThenInclude(entity => entity.Translations)
                                            .ThenInclude(entity => entity.Language)
                                    .Include(entity => entity.Cv);
        }

        public async Task<bool> CreateAsync(Application application)
        {
            await unitOfWork.Applications.InsertAsync(application);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Application application)
        {
            unitOfWork.Applications.Delete(application);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<Application> GetByIdAsync(int id)
        {
            return await unitOfWork.Applications.GetAsync(t => t.Id == id, include);
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await unitOfWork.Applications.GetAllAsync(include: include);
        }
    }
}
