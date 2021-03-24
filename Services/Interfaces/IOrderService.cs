using Restaurant_Website.Domain.Core;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Restaurant_Website.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetUserOrdersAsync(AppUser appUser);

        Task<bool> AddAsync(IEnumerable<Order> order);
        Task<bool> DeleteAsync(Order order);
        Task<bool> ClearAsync(AppUser user);
    }
}
