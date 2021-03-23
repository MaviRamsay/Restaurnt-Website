using Microsoft.AspNetCore.Mvc;
using Restaurant_Website.Models.Account;
using Microsoft.AspNetCore.Identity;
using Restaurant_Website.Domain.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant_Website.Infrastructure.Extensions;
using System.Collections.Generic;
using Restaurant_Website.Models.Menu;
using System.Linq;
using Restaurant_Website.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, 
                                IProductService productService, ICartService cartService, IHttpContextAccessor accessor)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.Login, loginModel.Password, loginModel.Remember, false);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                }
            }

            return PartialView();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser { UserName = registerModel.PhoneNumber, PhoneNumber = registerModel.PhoneNumber };
                var result = await userManager.CreateAsync(appUser, registerModel.Password);

                if (result.Succeeded)
                {
                    return await Login(new LoginViewModel { Login = registerModel.PhoneNumber, Password = registerModel.Password });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return PartialView();
        }
    }
}
