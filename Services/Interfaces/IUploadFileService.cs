using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;

namespace Restaurant_Website.Services.Interfaces
{
    public interface IUploadFileService
    {
        Task<UploadedFile> GetByIdAsync(int id);

        Task<UploadedFile> UploadAsync(IFormFile file);
        Task<bool> DeleteAsync(UploadedFile file);
    }
}
