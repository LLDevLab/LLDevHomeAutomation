using System;
using System.Linq;
using DbCommunicationLib;
using DbCommunicationLib.Model;
using WeatherForecastWorker.OpenWeatherMap.Dtos;

namespace WeatherForecastWorker.OpenWeatherMap.Controllers.EventControllers
{
    abstract class EventControllerBase
    {
        protected abstract string SensorName { get; }
        protected WeatherForecastDto Dto { get; private init; }
        protected HomeAutomationContext DbContext { get; private init; }

        protected DateTime EventDateTime
        {
            get
            {
                var unixDt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return unixDt.AddSeconds(Dto.Dt).ToLocalTime();
            }
        }

        protected EventControllerBase(HomeAutomationContext dbContext, WeatherForecastDto dto)
        {
            DbContext = dbContext;
            Dto = dto;
        }

        public void CreateSensorEvent()
        {
            var sensor = GetSensor();

            if (EventExist(sensor.Id))
                return;

            var events = DbContext.SensorEvents;
            events.Add(GetEventInstance(sensor.Id));

            Save();
        }

        protected abstract SensorEvent GetEventInstance(int sensorId);

        public Sensor GetSensor() => DbContext.Sensors.First(x => x.Name == SensorName);

        protected void Save() => DbContext.SaveChanges();

        protected bool EventExist(int sensorId) =>
            DbContext.SensorEvents.Any(x => x.SensorId == sensorId && x.EventDateTime == EventDateTime);
    }
}
