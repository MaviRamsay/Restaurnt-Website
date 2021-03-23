using System.Threading.Tasks;
using Restaurant_Website.Domain.Core;
using System.Collections.Generic;

namespace Restaurant_Website.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<bool> CreateAsync(Product product);
        Task<bool> EditAsync(int id, Product newProduct);
        Task<bool> DeleteAsync(int id);
    }
}
