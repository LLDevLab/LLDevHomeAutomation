using System;
using System.Threading;
using System.Threading.Tasks;
using DbCommunicationLib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherForecastWorker.OpenWeatherMap;
using WeatherForecastWorker.OpenWeatherMap.Controllers;

namespace WeatherForecastWorker.Settings
{
    public class Worker : BackgroundService
    {
        readonly ILogger<Worker> _logger;
        readonly TimeSpan _timeSpan;
        readonly ForecastReader _forecastReader;
        readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, WeatherOpenMapApiSettings _settings, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _timeSpan = new(0, 15, 0);
            _forecastReader = new(_settings);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                CreateOpenWeatherMapEvents();
                await Task.Delay(_timeSpan, stoppingToken);
            }
        }

        async void CreateOpenWeatherMapEvents()
        {
            var data = await _forecastReader.ReadForecastAsync("2.5");
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<HomeAutomationContext>();
            var controller = new WeatherForecastController(dbContext, data);
            controller.CreateSensorEvents();
        }
    }
}
