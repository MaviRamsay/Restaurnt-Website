using Restaurant_Website.Services.Interfaces;
using System.Threading.Tasks;
using Restaurant_Website.Domain.Core;
using System.Collections.Generic;
using Restaurant_Website.Domain.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;

namespace Restaurant_Website.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Func<IQueryable<Order>, IIncludableQueryable<Order, object>> include;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.include = i => i.Include(p => p.Product)
                                    .ThenInclude(t => t.Translations)
                                        .ThenInclude(l => l.Language);
        }

        public async Task<bool> AddAsync(IEnumerable<Order> orders)
        {
            if (orders is null) return false;

            await unitOfWork.Orders.InsertRangeAsync(orders);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Order order)
        {
            if (await unitOfWork.Orders.ContainsAsync(order))
            {
                unitOfWork.Orders.Delete(order);
                await unitOfWork.CommitAsync();

                return true;
            }
            else return false;
        }

        public async Task<bool> ClearAsync(AppUser user)
        {
            if (user?.Orders is null) return false;

            unitOfWork.Orders.DeleteRange(user.Orders);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await unitOfWork.Orders.GetAsync(t => t.Id == id, include);
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(AppUser appUser)
        {
            return await unitOfWork.Orders.GetAllAsync(t => t.User == appUser, include: include);
        }
    }
}
