using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> GetAllAsync();
        Task<Application> GetByIdAsync(int id);

        Task<bool> CreateAsync(Application application);
        Task<bool> DeleteAsync(Application application);

        Task<byte[]> ConvertCvToArrayAsync(IFormFile file);
    }
}
