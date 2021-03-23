using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Website.Services.Interfaces;
using AutoMapper;
using Restaurant_Website.Domain.Core;
using Restaurant_Website.Models.Menu;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Restaurant_Website.Controllers
{
    public class MenuController : Controller
    {
        private readonly IUploadFileService uploadFileService;
        private readonly IProductCategoryService productCategoryService;
        private readonly string userLanguage; 

        public MenuController(IUploadFileService uploadFileService, IProductCategoryService productCategoryService, IHttpContextAccessor accessor)
        {
            this.uploadFileService = uploadFileService;
            this.productCategoryService = productCategoryService;

            this.userLanguage = accessor.HttpContext.Request.Cookies["culture"] ?? accessor.HttpContext.Items["culture"].ToString();
        }

        public async Task<IActionResult> GetImage(int? id)
        {
            if (!id.HasValue) return NotFound();

            var img = await uploadFileService.GetByIdAsync(id.Value);

            if (img is null) return NotFound();
            else return new FileContentResult(img.Content, img.ContentType);
        }

        [HttpPost]
        public async Task<IActionResult> GetProducts(int categoryId)
        {
            var category = await productCategoryService.GetCategoryByIdAsync(categoryId);
            
            if (!(category is null))
            {
                IMapper productMapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductViewModel>()
                                            .ForMember(m => m.Name, opt => opt.MapFrom((s, d) => d.Name = s.Translations.First(t => t.Language.Code == userLanguage).Name))
                                            .ForMember(m => m.Description, opt => opt.MapFrom((s, d) => d.Description = s.Translations.First(t => t.Language.Code == userLanguage).Description)))
                                            .CreateMapper();

                var products = productMapper.Map<IEnumerable<ProductViewModel>>(category.Products);

                return PartialView("CategoryProducts", products);

            }
            else
                return NotFound();
        }

        [Route("menu")]
        public async Task<ViewResult> Index()
        {
            var categories = await productCategoryService.GetProductCategoriesAsync();

            IMapper mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductViewModel>()
                                            .ForMember(m => m.Name, opt => opt.MapFrom((s, d) => d.Name = s.Translations.First(t => t.Language.Code == userLanguage).Name))
                                            .ForMember(m => m.Description, opt => opt.MapFrom((s, d) => d.Description = s.Translations.First(t => t.Language.Code == userLanguage).Description));
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>()
                    .ForMember(m => m.Name, opt => opt.MapFrom((s, d) => d.Name = s.Translations.First(t => t.Language.Code == userLanguage).Name));
            }).CreateMapper();

            var model = mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
            return View(model);
        }
    }
}
