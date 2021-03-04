using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> GetApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(object id);

        Task<bool> CreateApplicationAsync(Application application);
        Task<bool> DeleteApplicationAsync(Application application);

        Task<byte[]> ConvertCvToArrayAsync(IFormFile file);
    }
}
