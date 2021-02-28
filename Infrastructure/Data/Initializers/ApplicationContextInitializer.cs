using Restaurant_Website.Infrastructure.Data.Context;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Restaurant_Website.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_Website.Infrastructure.Data.Initializers
{
    public class ApplicationContextInitializer
    {
        public static async Task InitializeAsync(ApplicationContext applicationContext)
        {
            await applicationContext.Database.EnsureCreatedAsync();

            if (!applicationContext.Languages.Any())
            {
                IEnumerable<Language> languages = new List<Language>
                {
                    new Language { Code = "en", Description = "ENG", AvalibleCountries = "us,gb,ca" },
                    new Language { Code = "ru", Description = "РУС", AvalibleCountries = "ru,ua,by" },
                    new Language { Code = "hy", Description = "ՀԱՅ", AvalibleCountries = "am" }
                };

                await applicationContext.Languages.AddRangeAsync(languages);
                await applicationContext.SaveChangesAsync();
            }

            if (!applicationContext.Vacancies.Any())
            {
                IEnumerable<Vacancy> vacancies = new List<Vacancy>
                {
                    new Vacancy { IsActive = true }, // cooker 
                    new Vacancy { IsActive = false }, // manager
                    new Vacancy { IsActive = true }, // waiter 
                    new Vacancy { IsActive = true }, // cleaner 
                    new Vacancy { IsActive = true } // cashier 
                };

                await applicationContext.Vacancies.AddRangeAsync(vacancies);
                await applicationContext.SaveChangesAsync();
            }

            if (!applicationContext.VacancyTranslations.Any())
            {
                IEnumerable<VacancyLang> vacancies = new List<VacancyLang>
                {
                    // cooker
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 1), Vacancy = applicationContext.Vacancies.First(t => t.Id == 1), VacancyName = "Cooker" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 2), Vacancy = applicationContext.Vacancies.First(t => t.Id == 1), VacancyName = "Повар" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 3), Vacancy = applicationContext.Vacancies.First(t => t.Id == 1), VacancyName = "Խոհարար" },

                    // manager
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 1), Vacancy = applicationContext.Vacancies.First(t => t.Id == 2), VacancyName = "Manager" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 2), Vacancy = applicationContext.Vacancies.First(t => t.Id == 2), VacancyName = "Менеджер" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 3), Vacancy = applicationContext.Vacancies.First(t => t.Id == 2), VacancyName = "Մենեջեր" },

                    // waiter
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 1), Vacancy = applicationContext.Vacancies.First(t => t.Id == 3), VacancyName = "Waiter" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 2), Vacancy = applicationContext.Vacancies.First(t => t.Id == 3), VacancyName = "Официант(-ка)" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 3), Vacancy = applicationContext.Vacancies.First(t => t.Id == 3), VacancyName = "Խոհարար(-ուհի)" },

                    // cleaner
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 1), Vacancy = applicationContext.Vacancies.First(t => t.Id == 4), VacancyName = "Cleaner" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 2), Vacancy = applicationContext.Vacancies.First(t => t.Id == 4), VacancyName = "Уборщик(-ица)" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 3), Vacancy = applicationContext.Vacancies.First(t => t.Id == 4), VacancyName = "Հավաքարար(-ուհի)" },

                    // cashier
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 1), Vacancy = applicationContext.Vacancies.First(t => t.Id == 5), VacancyName = "Cashier" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 2), Vacancy = applicationContext.Vacancies.First(t => t.Id == 5), VacancyName = "Кассир(-ша)" },
                    new VacancyLang { Language = applicationContext.Languages.First(t => t.Id == 3), Vacancy = applicationContext.Vacancies.First(t => t.Id == 5), VacancyName = "Գանձապահ(-ուհի)" }
                };

                await applicationContext.VacancyTranslations.AddRangeAsync(vacancies);
                await applicationContext.SaveChangesAsync();
            }
        }
    }
}
