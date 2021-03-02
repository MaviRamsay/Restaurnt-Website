﻿using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<bool> CreateApplicationAsync(Application application)
        {
            await unitOfWork.Applications.InsertAsync(application);

            await unitOfWork.CommitAsync();

            return true;
        }

        public bool DeleteApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public Task<Application> GetApplicationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Application>> GetApplicationsAsync()
        {
            throw new NotImplementedException();
        }
    }
}