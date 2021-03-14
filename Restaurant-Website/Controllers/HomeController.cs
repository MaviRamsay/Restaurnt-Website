using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant_Website.Models;
using Restaurant_Website.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Restaurant_Website.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using Restaurant_Website.Models.Home;
using System.Linq;

namespace Restaurant_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IApplicationService applicationService;
        private readonly IVacancyService vacancyService;
        private readonly IUploadFileService uploadFileService;

        public HomeController(ILogger<HomeController> logger, 
                                IApplicationService applicationService, 
                                IVacancyService vacancyService,
                                IUploadFileService uploadFileService)
        {
            this.logger = logger;
            this.applicationService = applicationService;
            this.vacancyService = vacancyService;
            this.uploadFileService = uploadFileService;
        }

        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        [Route("about")]
        public ViewResult About()
        {
            return View();
        }

        [HttpGet, Route("work")]
        public async Task<ViewResult> Work()
        {
            string lang = HttpContext.Request.Cookies["culture"] ?? HttpContext.Items["culture"].ToString();

            var translations = await vacancyService.GetTranslationsAsync(lang);

            SelectList selectListItems = new SelectList (translations, 
                        nameof(VacancyLang.VacancyId), 
                        nameof(VacancyLang.VacancyName)
            );

            ViewBag.Vacancies = selectListItems;   
            
            return View();
        }

        [HttpPost, Route("work"), ValidateAntiForgeryToken]
        public async Task<ViewResult> Work(ApplicationViewModel applicationViewModel)
        {
            if(ModelState.IsValid)
            {
                var vacancy = await vacancyService.GetByIdAsync(applicationViewModel.Vacancy);
                var cv = await uploadFileService.UploadAsync(applicationViewModel.Cv);

                IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationViewModel, Application>()
                    .ForMember(m => m.SubmitDate, opt => opt.MapFrom((s, d) => d.SubmitDate = DateTime.Now))
                    .ForMember(m => m.Vacancy, opt => opt.MapFrom((s, d) => d.Vacancy = vacancy))
                    .ForMember(m => m.Cv, opt => opt.MapFrom((s, d) => d.Cv = cv)))
                    .CreateMapper();
                
                await applicationService.CreateAsync(mapper.Map<Application>(applicationViewModel));

                return View("Complete");
            }
             
            return await Work();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
