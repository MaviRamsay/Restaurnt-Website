using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<bool> CreateAsync(Language language);
        Task<bool> EditAsync(Language language);
        Task<bool> DeleteAsync(Language language);

        Task<Language> GetByCodeAsync(string code);
        Task<string> GetDefaultCodeAsync(HttpContext context);
        Task<IEnumerable<Language>> GetAllAsync();
    }
}
