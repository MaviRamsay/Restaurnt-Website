using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant_Website.Domain.Interfaces;
using Restaurant_Website.Infrastructure.Middlewares;
using Restaurant_Website.Infrastructure.Data.Implementation;
using Restaurant_Website.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Restaurant_Website.Services.Interfaces;
using Restaurant_Website.Services.Implementations;

namespace Restaurant_Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Restaurant_Website.Infrastructure.Data")));

            services.AddSingleton(typeof(IRepositoty<>), typeof(BaseRepository<>));

            services.AddHttpContextAccessor();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IUploadFileService, UploadFileService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMiddleware<ConfigureLanguageMiddleware>();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
