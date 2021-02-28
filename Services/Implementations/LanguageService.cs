using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurant_Website.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public LanguageService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public async Task<bool> CreateLanguageAsync()
        {
            throw new NotImplementedException();
        }

        public bool DeleteLanguage()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditLanguageAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Language> GetLanguageAsync(string code)
        {
            return await unitOfWork.Languages.GetAsync(t => t.Code == code);
        }

        public async Task<string> GetDefaultLanguageAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress;

            string requestCountry = await GetCountryCodeByIpAsync(ip);
            Language languageInstance = await unitOfWork.Languages.GetAsync(t => t.AvalibleCountries.Contains(requestCountry));

            string languageCode;

            if (languageInstance is null)
            {
                languageCode = configuration
                                    .GetSection("AppSettings")
                                    .GetSection("DefaultLanguage")
                                    .Value;
            }
            else
            {
                languageCode = languageInstance.Code;
            }

            return languageCode;
        }

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return await unitOfWork.Languages.GetAllAsync();
        }

        private async Task<string> GetCountryCodeByIpAsync(IPAddress ip)
        {
            using var client = new WebClient();
            Uri uri = new Uri("https://www.ip2location.com/demo/" + ip.ToString());

            string htmlCode = await client.DownloadStringTaskAsync(uri);
            string pattern = @"data-toggle=""tooltip"">.*<\/a> \[(.*)\] <i class=""fa fa-info-circle\"">";

            var match = Regex.Match(htmlCode, pattern, RegexOptions.Singleline);

            return match.Groups[1].ToString() == string.Empty ? null : match.Groups[1].ToString();
        }
    }
}
