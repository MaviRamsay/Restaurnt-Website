using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<bool> AddProductAsync(Cart cart)
        {
            var record = await unitOfWork.Carts.GetAsync(t => t.Product == cart.Product && t.User == cart.User);

            if (record is null)
            {
                await unitOfWork.Carts.InsertAsync(cart);
                await unitOfWork.CommitAsync();

                return true;
            }
            else return false;
        }

        public async Task ClearCartAsync(AppUser user)
        {
            unitOfWork.Carts.DeleteRange(user.Cart);
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> RemoveProductAsync(Cart cart)
        {
            if (await unitOfWork.Carts.ContainsAsync(cart))
            {
                unitOfWork.Carts.Delete(cart);
                await unitOfWork.CommitAsync();

                return true;
            }
            else return false;
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            unitOfWork.Carts.Delete(id);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}
