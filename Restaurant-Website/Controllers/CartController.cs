using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Models.Cart;
using Restaurant_Website.Models.Menu;
using Restaurant_Website.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Website.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IProductService productService;
        private readonly ICartService cartService;
        private readonly string userLanguage;

        public CartController(UserManager<AppUser> userManager, IProductService productService, ICartService cartService, IHttpContextAccessor accessor)
        {
            this.userManager = userManager;
            this.productService = productService;
            this.cartService = cartService;
            this.userLanguage = accessor.HttpContext.Request.Cookies["culture"] ?? accessor.HttpContext.Items["culture"].ToString();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCart()
        {
            if (!User.Identity.IsAuthenticated)
                return PartialView("Login");

            var cart = await GetCartAsync();

            if (!(cart is null)) return PartialView("Cart", cart);
            return NoContent();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int count, int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return PartialView("Login");

            var product = await productService.GetByIdAsync(productId);
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if (!(product is null) && !(user is null))
            {
                Cart cart = new Cart { Product = product, Count = count, User = user };
                await cartService.AddProductAsync(cart);

                return PartialView("CartIcon");
            }
            else return NotFound();
        }

        [Authorize]
        public async Task<PartialViewResult> DeleteCartItem(int itemId)
        {
            var cart = await GetCartAsync();
            await cartService.RemoveProductAsync(itemId);

            return PartialView("Cart", cart.Where(t => t.Id != itemId));
        }

        [Authorize]
        public async Task<IActionResult> ClearCart()
        {
            var user = await userManager.Users.Include(t => t.Cart)
                                        .SingleAsync(t => t.UserName == User.Identity.Name);

            if (!(user is null))
            {
                await cartService.ClearCartAsync(user);
                return RedirectToAction("Index", "Menu");
            }
            else return NotFound();
        }

        [Authorize]
        public async Task<IActionResult> BuyCart()
        {
            var cart = await GetCartAsync();

            if (cart is null)
            {
                return RedirectToAction("Index", "Home");
            }
            else return View(cart);
        }

        private async Task<IEnumerable<CartViewModel>> GetCartAsync()
        {
            var user = await userManager.Users.Include(t => t.Cart)
                                                .ThenInclude(c => c.Product)
                                                    .ThenInclude(p => p.Translations)
                                                        .ThenInclude(t => t.Language)
                                        .SingleAsync(t => t.UserName == User.Identity.Name);

            if (!(user is null))
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductViewModel>().ForMember(m => m.Name, opt => opt.MapFrom(s => s.Translations.First(t => t.Language.Code == userLanguage).Name));
                    cfg.CreateMap<Cart, CartViewModel>();
                });
                var mapper = config.CreateMapper();

                return mapper.Map<IEnumerable<CartViewModel>>(user.Cart);
            }
            else return null;
        }
    }
}
