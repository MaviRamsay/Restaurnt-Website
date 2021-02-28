using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<bool> CreateLanguageAsync();
        Task<bool> EditLanguageAsync();
        bool DeleteLanguage();

        Task<Language> GetLanguageAsync(string code);
        Task<string> GetDefaultLanguageAsync(HttpContext context);
        Task<IEnumerable<Language>> GetLanguagesAsync();
    }
}
