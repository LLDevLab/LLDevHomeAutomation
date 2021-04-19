using DbCommunicationLib.Model;
using System;
using System.Globalization;

namespace DbCommunicationLib.Controller.Sensors
{
    abstract class DoubleSensorController: SensorControllerBase
    {

        protected SensorEvent CreateSensorEvent(string eventDescription)
        {
            if (!float.TryParse(eventDescription, NumberStyles.Float, CultureInfo.InvariantCulture, out var val))
                throw new ArgumentException($"Cannot convert artument '{eventDescription}' to float.");

            return new SensorEvent
            {
                Sensor = SensorModel,
                EventDateTime = DateTime.Now,
                EventDoubleValue = val
            };
        }

        public DoubleSensorController(Sensor sensorModel) : base(sensorModel)
        {
        }
    }
}
