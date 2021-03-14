using Restaurant_Website.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task CreateAsync(ProductCategory category);
        Task EditAsync(ProductCategory category);
        Task<bool> DeleteAsync(ProductCategory category);

        Task<ProductCategory> GetCategoryByIdAsync(int id);
        Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync();
    }
}
