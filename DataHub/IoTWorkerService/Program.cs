using DbCommunicationLib;
using IoTCommunicationLib;
using IoTCommunicationLib.IoTSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

                    var sqlWorkerOptions = configuration.GetSection("SqlWorkerOptions").Get<SqlServerSettings>();
                    var mqttWorkerSettings = configuration.GetSection("MqttOptions").Get<MqttSettings>();
                    services.AddSingleton(mqttWorkerSettings as ICommunicationSettings);
                    services.AddSingleton(sqlWorkerOptions as IDbContextSettings);
                    services.AddDbContext<HomeAutomationContext>();
                    services.AddHostedService<Worker>();
                });
    }
}
