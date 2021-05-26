using System;
using DbCommunicationLib;
using DbCommunicationLib.Model;
using WeatherForecastWorker.OpenWeatherMap.Dtos;

namespace WeatherForecastWorker.OpenWeatherMap.Controllers.EventControllers
{
    class TemperatureEventController : EventControllerBase
    {
        protected override string SensorName => "OpenMapTemp";

        public TemperatureEventController(HomeAutomationContext dbContext, WeatherForecastDto dto) : 
            base(dbContext, dto)
        {
        }

        protected override SensorEvent GetEventInstance(int sensorId) => new SensorEvent
        {
            SensorId = sensorId,
            EventDateTime = EventDateTime,
            EventDoubleValue = KelvinToCelsius(Dto.Main.Temp)
        };

        float KelvinToCelsius(float kelvin) => kelvin - 273.15f;
    }
}
