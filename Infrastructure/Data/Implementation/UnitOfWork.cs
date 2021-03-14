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

        private IRepositoty<Product> productRepository;
        private IRepositoty<ProductCategory> productCategoryRepository;
        private IRepositoty<ProductLang> productLangRepository;
        private IRepositoty<ProductCategoryLang> productCategoryLangRepository;

        public UnitOfWork(ApplicationContext context) => this.context = context;

        public IRepositoty<Language> Languages { get => languageRepository ??= new BaseRepository<Language>(context); }
        public IRepositoty<Application> Applications { get => applicationRepository ??= new BaseRepository<Application>(context); }
        public IRepositoty<Vacancy> Vacancies { get => vacancyRepository ??= new BaseRepository<Vacancy>(context); }
        public IRepositoty<VacancyLang> VacancyTranslations { get => vacancyLangRepository ??= new BaseRepository<VacancyLang>(context); }
        public IRepositoty<UploadedFile> UploadedFiles { get => uploadedFilesRepository ??= new BaseRepository<UploadedFile>(context); }

        public IRepositoty<Product> Products { get => productRepository ??= new BaseRepository<Product>(context); }
        public IRepositoty<ProductCategory> ProductCategories { get => productCategoryRepository ??= new BaseRepository<ProductCategory>(context); }
        public IRepositoty<ProductLang> ProductTranslations { get => productLangRepository ??= new BaseRepository<ProductLang>(context); }
        public IRepositoty<ProductCategoryLang> ProductCategoryTranslations { get => productCategoryLangRepository ??= new BaseRepository<ProductCategoryLang>(context); }

        public async Task CommitAsync() => await context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
        {
            //await CommitAsync();
        }
    }
}
