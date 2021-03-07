using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<bool> CreateAsync();
        Task<bool> EditAsync();
        Task<bool> DeleteAsync();

        Task<Language> GetByCodeAsync(string code);
        Task<string> GetDefaultCodeAsync(HttpContext context);
        Task<IEnumerable<Language>> GetAllAsync();
    }
}
