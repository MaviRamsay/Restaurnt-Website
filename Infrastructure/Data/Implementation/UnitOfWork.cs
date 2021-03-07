using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Restaurant_Website.Infrastructure.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly ApplicationContext context;

        private IRepositoty<Language> languageRepository;
        private IRepositoty<Application> applicationRepository;
        private IRepositoty<Vacancy> vacancyRepository;
        private IRepositoty<VacancyLang> vacancyLangRepository;
        private IRepositoty<UploadedFile> uploadedFilesRepository;

        public UnitOfWork(ApplicationContext context) => this.context = context;

        public IRepositoty<Language> Languages { get => languageRepository ??= new BaseRepository<Language>(context); }
        public IRepositoty<Application> Applications { get => applicationRepository ??= new BaseRepository<Application>(context); }
        public IRepositoty<Vacancy> Vacancies { get => vacancyRepository ??= new BaseRepository<Vacancy>(context); }
        public IRepositoty<VacancyLang> VacancyTranslations { get => vacancyLangRepository ??= new BaseRepository<VacancyLang>(context); }
        public IRepositoty<UploadedFile> UploadedFiles { get => uploadedFilesRepository ??= new BaseRepository<UploadedFile>(context); }

        public async Task CommitAsync() => await context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
        {
            //await CommitAsync();
        }
    }
}
