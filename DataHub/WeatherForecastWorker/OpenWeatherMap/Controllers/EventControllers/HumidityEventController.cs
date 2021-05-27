using DbCommunicationLib;
using DbCommunicationLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastWorker.OpenWeatherMap.Dtos;

namespace WeatherForecastWorker.OpenWeatherMap.Controllers.EventControllers
{
    class HumidityEventController : EventControllerBase
    {
        protected override string SensorName => "OpenMapHum";

        public HumidityEventController(HomeAutomationContext dbContext, WeatherForecastDto dto) :
            base(dbContext, dto)
        {
        }

        protected override SensorEvent GetEventInstance(int sensorId) => new()
        {
            SensorId = sensorId,
            EventDateTime = EventDateTime,
            EventDoubleValue = Dto.Main.Humidity
        };
    }
}
