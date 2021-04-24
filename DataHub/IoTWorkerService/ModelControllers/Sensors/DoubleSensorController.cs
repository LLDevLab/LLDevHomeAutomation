using DbCommunicationLib.Model;
using System;
using System.Globalization;

namespace DbCommunicationLib.Controller.Sensors
{
    abstract class DoubleSensorController: SensorControllerBase
    {
        public DoubleSensorController(Sensor sensorModel, HomeAutomationContext dbContext) : base(sensorModel, dbContext)
        {
        }

        protected SensorEvent CreateSensorEvent(string eventValue)
        {
            if (!float.TryParse(eventValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var val))
                throw new ArgumentException($"Cannot convert artument '{eventValue}' to float.");

            return new SensorEvent
            {
                Sensor = SensorModel,
                EventDateTime = DateTime.Now,
                EventDoubleValue = val
            };
        }
    }
}
