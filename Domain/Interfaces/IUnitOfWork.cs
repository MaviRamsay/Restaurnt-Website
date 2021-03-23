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

        IRepositoty<Product> Products { get; }
        IRepositoty<ProductCategory> ProductCategories { get; }
        IRepositoty<ProductLang> ProductTranslations { get; }
        IRepositoty<ProductCategoryLang> ProductCategoryTranslations { get; }

        IRepositoty<Cart> Carts { get; }

        Task CommitAsync();
    }
}
