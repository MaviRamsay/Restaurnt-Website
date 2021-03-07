using Microsoft.AspNetCore.Http;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(Application application)
        {
            await unitOfWork.Applications.InsertAsync(application);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Application application)
        {
            unitOfWork.Applications.Delete(application);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<Application> GetByIdAsync(int id)
        {
            return await unitOfWork.Applications.GetByIdAsync(id);
        }

        public Task<IEnumerable<Application>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> ConvertCvToArrayAsync(IFormFile file)
        {
            byte[] cv;
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                cv = ms.ToArray();
            }

            return cv;
        }
    }
}
