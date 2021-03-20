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

            if (!applicationContext.ProductCategories.Any())
            {
                IEnumerable<ProductCategory> productCategories = new List<ProductCategory>
                {
                    new ProductCategory { Image = null },
                    new ProductCategory() { Image = null },
                    new ProductCategory() { Image = null }
                };

                await applicationContext.ProductCategories.AddRangeAsync(productCategories);
                await applicationContext.SaveChangesAsync();
            }

            if (!applicationContext.ProductCategoryTranslations.Any())
            {
                IEnumerable<ProductCategoryLang> productCategoryTranslations = new List<ProductCategoryLang>
                {
                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 1), Category = applicationContext.ProductCategories.First(t => t.Id == 1), Name = "Drink" },
                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 2), Category = applicationContext.ProductCategories.First(t => t.Id == 1), Name = "Бухло" },
                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 3), Category = applicationContext.ProductCategories.First(t => t.Id == 1), Name = "Խմիչք" },

                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 1), Category = applicationContext.ProductCategories.First(t => t.Id == 2), Name = "Dishes" },
                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 2), Category = applicationContext.ProductCategories.First(t => t.Id == 2), Name = "Блюды" },
                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 3), Category = applicationContext.ProductCategories.First(t => t.Id == 2), Name = "Ուտեստներ" },

                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 1), Category = applicationContext.ProductCategories.First(t => t.Id == 3), Name = "Salates" },
                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 2), Category = applicationContext.ProductCategories.First(t => t.Id == 3), Name = "Салаты" },
                    new ProductCategoryLang { Language = applicationContext.Languages.First(t => t.Id == 3), Category = applicationContext.ProductCategories.First(t => t.Id == 3), Name = "Աղցաններ" }
                };

                await applicationContext.ProductCategoryTranslations.AddRangeAsync(productCategoryTranslations);
                await applicationContext.SaveChangesAsync();
            }

            if (!applicationContext.Products.Any())
            {
                IEnumerable<Product> products = new List<Product>
                {
                    new Product { Category = applicationContext.ProductCategories.First(t => t.Id == 1), Image = null, Price = 12.00M },
                    new Product { Category = applicationContext.ProductCategories.First(t => t.Id == 2), Image = null, Price = 15.00M },
                    new Product { Category = applicationContext.ProductCategories.First(t => t.Id == 3), Image = null, Price = 18.00M },
                };

                await applicationContext.Products.AddRangeAsync(products);
                await applicationContext.SaveChangesAsync();
            }

            if (!applicationContext.ProductTranslations.Any())
            {
                IEnumerable<ProductLang> productsTranslations = new List<ProductLang>
                {
                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 1), Product = applicationContext.Products.First(t => t.Id == 1), Name = "Beer", Description = "Tooyn beer" },
                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 2), Product = applicationContext.Products.First(t => t.Id == 1), Name = "Пиво", Description = "Крутое пиво" },
                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 3), Product = applicationContext.Products.First(t => t.Id == 1), Name = "Գարեջուր", Description = "Ուժեղ գարեջուր" },

                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 1), Product = applicationContext.Products.First(t => t.Id == 2), Name = "Club", Description = "Tasty club" },
                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 2), Product = applicationContext.Products.First(t => t.Id == 2), Name = "Клаб", Description = "Вкусный клаб" },
                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 3), Product = applicationContext.Products.First(t => t.Id == 2), Name = "Քլաբ", Description = "Համեղ քլաբ" },

                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 1), Product = applicationContext.Products.First(t => t.Id == 3), Name = "Olivien", Description = "Fresh" },
                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 2), Product = applicationContext.Products.First(t => t.Id == 3), Name = "Оливье", Description = "Свежее" },
                    new ProductLang { Language = applicationContext.Languages.First(t => t.Id == 3), Product = applicationContext.Products.First(t => t.Id == 3), Name = "Մայրաքաղաքային աղցան", Description = "Թարմ" },
                };

                await applicationContext.ProductTranslations.AddRangeAsync(productsTranslations);
                await applicationContext.SaveChangesAsync();
            }
        }
    }
}
