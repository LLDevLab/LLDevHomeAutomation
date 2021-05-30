using DbCommunicationLib;
using DbCommunicationLib.Model;
using WeatherForecastWorker.OpenWeatherMap.Dtos;

namespace WeatherForecastWorker.OpenWeatherMap.Controllers.EventControllers
{
    class WindSpeedEventController : EventControllerBase
    {
        protected override string SensorName => "OpenMapWindSpeed";

        public WindSpeedEventController(HomeAutomationContext dbContext, WeatherForecastDto dto) :
            base(dbContext, dto)
        {
        }

        protected override SensorEvent GetEventInstance(int sensorId) => new()
        {
            SensorId = sensorId,
            EventDateTime = EventDateTime,
            EventDoubleValue = Dto.Wind.Speed
        };
    }
}
