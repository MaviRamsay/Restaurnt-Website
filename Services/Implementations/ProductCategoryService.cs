using Microsoft.EntityFrameworkCore;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            return await unitOfWork.ProductCategories.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync()
        {
            return await unitOfWork.ProductCategories.GetAllAsync(include: t => t.Include(t => t.Translations)
                                                                                    .ThenInclude(t => t.Language)
                                                                                .Include(t => t.Products)
                                                                                    .ThenInclude(t => t.Translations)
                                                                                        .ThenInclude(t => t.Language));
        }
    }
}
