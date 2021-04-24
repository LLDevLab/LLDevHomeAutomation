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

        protected SensorEvent CreateNewEvent(string sensorValue)
        {
            if (!float.TryParse(sensorValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var val))
                throw new ArgumentException($"Cannot convert artument '{sensorValue}' to float.");

            return new SensorEvent
            {
                Sensor = SensorModel,
                EventDateTime = DateTime.Now,
                EventDoubleValue = val
            };
        }
    }
}
