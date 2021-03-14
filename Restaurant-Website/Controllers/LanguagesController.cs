using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Http;
using Restaurant_Website.Services.Interfaces;
using AutoMapper;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Models.Home;

namespace Restaurant_Website.Controllers
{
    [ViewComponent(Name = "Languages")]
    public class LanguagesController : Controller
    {
        private readonly ILanguageService languageService;
        private readonly IHttpContextAccessor accessor;
        private readonly string defaultLanguage;

        public LanguagesController(ILanguageService languageService, IHttpContextAccessor accessor)
        {
            this.languageService = languageService;
            this.accessor = accessor;
            this.defaultLanguage = languageService.GetDefaultCodeAsync(accessor.HttpContext).Result;
        }

        public async Task<RedirectResult> ChangeLanguage(string lang)
        {
            string language = (await languageService.GetByCodeAsync(lang))?.Code ?? defaultLanguage;

            if (HttpContext.Request.Cookies["culture"] != null)
            {
                HttpContext.Response.Cookies.Delete("culture");
            }

            HttpContext.Response.Cookies.Append("culture", language);

            return Redirect(Request.Headers["Referer"]);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = (await languageService.GetAllAsync()).OrderByDescending(t => t.Code == (accessor.HttpContext.Request.Cookies["culture"] ?? defaultLanguage));

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Language, LanguageViewModel>()).CreateMapper();
            var languageViewModels = mapper.Map<IEnumerable<LanguageViewModel>>(languages);

            return await Task.FromResult<IViewComponentResult>(new ViewViewComponentResult
            {
                ViewData = new ViewDataDictionary<IEnumerable<LanguageViewModel>>(this.ViewData, languageViewModels)  
            });
        }
    }
}
