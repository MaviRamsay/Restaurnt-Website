using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restaurant_Website.Services.Interfaces;

namespace Restaurant_Website.Infrastructure.Middlewares
{
    public class ConfigureLanguageMiddleware
    {
        private readonly RequestDelegate nextDelegate;

        public ConfigureLanguageMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext context, ILanguageService languageService)
        {
            string clientLanguage = context.Request.Cookies["culture"];
            string language = null;

            if (!(clientLanguage is null))
            {
                language = (await languageService.GetByCodeAsync(clientLanguage))?.Code;
            }

            if (language is null)
            {
                language = await languageService.GetDefaultCodeAsync(context);

                context.Items["culture"] = language; // for current request 
                context.Response.Cookies.Append("culture", language); // for next request
            }

            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            await nextDelegate(context);
        }
    }
}
