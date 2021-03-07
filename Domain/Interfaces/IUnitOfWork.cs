using System.Threading.Tasks;
using Restaurant_Website.Domain.Core;

namespace Restaurant_Website.Domain.Interfaces
{
    public interface IUnitOfWork 
    {
        IRepositoty<Language> Languages { get; }
        IRepositoty<Application> Applications { get; }
        IRepositoty<Vacancy> Vacancies { get; }
        IRepositoty<VacancyLang> VacancyTranslations { get; }
        IRepositoty<UploadedFile> UploadedFiles { get; }

        Task CommitAsync();
    }
}
