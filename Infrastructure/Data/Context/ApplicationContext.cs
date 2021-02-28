using Restaurant_Website.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Restaurant_Website.Infrastructure.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyLang> VacancyTranslations { get; set; }
        public DbSet<Application> Applications { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext)
            : base(dbContext)
        {

        }
    }
}
