using System.Collections.Generic;
using DbCommunicationLib;
using WeatherForecastWorker.OpenWeatherMap.Dtos;
using WeatherForecastWorker.OpenWeatherMap.Controllers.EventControllers;

namespace WeatherForecastWorker.OpenWeatherMap.Controllers
{
    class WeatherForecastController
    {
        readonly List<EventControllerBase> _eventControllers;

        public WeatherForecastController(HomeAutomationContext dbContext, WeatherForecastDto dto)
        {
            _eventControllers = new()
            {
                new TemperatureEventController(dbContext, dto),
                new PressureEventController(dbContext, dto),
                new HumidityEventController(dbContext, dto)
            };
        }

        public void CreateSensorEvents()
        {
            foreach (var controller in _eventControllers)
                controller.CreateSensorEvent();
        }
    }
}
