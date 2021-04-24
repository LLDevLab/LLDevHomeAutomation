using DbCommunicationLib;
using IoTCommunicationLib.IoTSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace IoTWorkerService
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
                    var mqttWorkerSettings = configuration.GetSection("MqttOptions").Get<MqttSettings>();
                    services.AddSingleton(mqttWorkerSettings as ICommunicationSettings);
                    services.AddDbContext<HomeAutomationContext>(options => options.UseNpgsql(connectionString));
                    services.AddHostedService<Worker>();
                });
    }
}
