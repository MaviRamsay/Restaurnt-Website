using System.Threading.Tasks;
using System.Collections.Generic;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_Website.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.include = inc => inc.Include(t => t.Translations)
                                        .ThenInclude(t => t.Language)
                                     .Include(t => t.Image)
                                     .Include(t => t.Category);
        }

        public Task<bool> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(int id, Product newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return unitOfWork.Products.GetAsync(t => t.Id == id, include);
        }
    }
}
