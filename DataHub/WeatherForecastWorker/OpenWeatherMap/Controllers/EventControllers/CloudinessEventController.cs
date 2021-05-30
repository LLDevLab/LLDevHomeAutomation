using DbCommunicationLib;
using DbCommunicationLib.Model;
using WeatherForecastWorker.OpenWeatherMap.Dtos;

namespace WeatherForecastWorker.OpenWeatherMap.Controllers.EventControllers
{
    class CloudinessEventController : EventControllerBase
    {
        protected override string SensorName => "OpenMapClouds";

        public CloudinessEventController(HomeAutomationContext dbContext, WeatherForecastDto dto) :
            base(dbContext, dto)
        {
        }

        protected override SensorEvent GetEventInstance(int sensorId) => new()
        {
            SensorId = sensorId,
            EventDateTime = EventDateTime,
            EventDoubleValue = Dto.Clouds.All
        };
    }
}
