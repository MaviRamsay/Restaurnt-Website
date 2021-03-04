using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Restaurant_Website.Infrastructure.Data.Context;
using Restaurant_Website.Infrastructure.Data.Initializers;

namespace Restaurant_Website
{
    public class Program
    {
        public async static Task CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationContext>();
            await ApplicationContextInitializer.InitializeAsync(context);
        }

        public async static Task Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                var host = CreateHostBuilder(args).Build();

                await CreateDbIfNotExists(host);

                await host.RunAsync();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              })
              .ConfigureLogging(logging =>
              {
                  logging.ClearProviders();
                  logging.SetMinimumLevel(LogLevel.Trace);
              })
              .UseNLog();
    }
}
