using Restaurant_Website.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_Website.Infrastructure.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyLang> VacancyTranslations { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCategoryLang> ProductCategoryTranslations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLang> ProductTranslations { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext)
            : base(dbContext)
        {

        }
    }
}
