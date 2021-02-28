using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
            string language = context.Request.Cookies["culture"];

            if (language is null)
            {
                language = await languageService.GetDefaultLanguageAsync(context);

                context.Response.Cookies.Append("culture", language);
            }

            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            await nextDelegate(context);
        }
    }
}
