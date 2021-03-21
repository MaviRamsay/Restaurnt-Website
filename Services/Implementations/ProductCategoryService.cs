using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Func<IQueryable<ProductCategory>, IIncludableQueryable<ProductCategory, object>> include;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.include = inc => inc.Include(t => t.Translations)
                                        .ThenInclude(t => t.Language)
                                    .Include(t => t.Products)
                                        .ThenInclude(t => t.Translations)
                                            .ThenInclude(t => t.Language);
        }

        public async Task CreateAsync(ProductCategory category)
        {
            await unitOfWork.ProductCategories.InsertAsync(category);
        }

        public async Task<bool> DeleteAsync(ProductCategory category)
        {
            if (await unitOfWork.ProductCategories.ContainsAsync(category))
            {
                unitOfWork.ProductCategories.Delete(category);
                return true;
            }

            return false;
        }

        public Task EditAsync(ProductCategory category)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductCategory> GetCategoryByIdAsync(int id)
        {
            return await unitOfWork.ProductCategories.GetAsync(t => t.Id == id, include);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync()
        {
            return await unitOfWork.ProductCategories.GetAllAsync(include: include);
        }
    }
}
