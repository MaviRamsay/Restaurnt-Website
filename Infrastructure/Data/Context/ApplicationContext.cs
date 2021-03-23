using Restaurant_Website.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Restaurant_Website.Infrastructure.Data.Context
{
    public class ApplicationContext : IdentityDbContext<AppUser>
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

        public DbSet<Cart> Carts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext)
            : base(dbContext)
        {

        }
    }
}
