using DbCommunicationLib;
using DbCommunicationLib.Model;
using WeatherForecastWorker.OpenWeatherMap.Dtos;

namespace WeatherForecastWorker.OpenWeatherMap.Controllers.EventControllers
{
    class PressureEventController : EventControllerBase
    {
        protected override string SensorName => "OpenMapPress";

        public PressureEventController(HomeAutomationContext dbContext, WeatherForecastDto dto) :
            base(dbContext, dto)
        {
        }

        protected override SensorEvent GetEventInstance(int sensorId) => new()
        {
            SensorId = sensorId,
            EventDateTime = EventDateTime,
            EventDoubleValue = ToPascals(Dto.Main.Pressure)
        };

        double ToPascals(int hPa) => hPa * 100;
    }
}
