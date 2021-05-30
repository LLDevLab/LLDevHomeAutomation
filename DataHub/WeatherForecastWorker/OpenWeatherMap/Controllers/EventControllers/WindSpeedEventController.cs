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
            EventDoubleValue = MphToMs(Dto.Wind.Speed)
        };

        /// <summary>
        /// Miles per hour to m/s
        /// </summary>
        double MphToMs(float mphSpeed) => mphSpeed * 0.44704;
    }
}
