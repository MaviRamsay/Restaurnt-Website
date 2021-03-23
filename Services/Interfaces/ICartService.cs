using System.Threading.Tasks;
using Restaurant_Website.Domain.Core;

namespace Restaurant_Website.Services.Interfaces
{
    public interface ICartService
    {
        Task<bool> AddProductAsync(Cart cart);
        Task<bool> RemoveProductAsync(Cart cart);

        Task<bool> RemoveProductAsync(int id);
        Task ClearCartAsync(AppUser user);
    }
}
