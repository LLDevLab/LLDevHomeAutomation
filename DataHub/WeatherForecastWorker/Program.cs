using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DbCommunicationLib;
using WeatherForecastWorker.Settings;

namespace WeatherForecastWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    var connectionString = configuration.GetConnectionString("HomeAutomation");
                    var openMapSettings = configuration.GetSection("WeatherOpenMapApiSettings").Get<WeatherOpenMapApiSettings>();
                    services.AddSingleton(openMapSettings);
                    services.AddDbContext<HomeAutomationContext>(options => options.UseNpgsql(connectionString));
                    services.AddHostedService<Worker>();
                });
    }
}
