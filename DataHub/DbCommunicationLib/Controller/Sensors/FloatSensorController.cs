using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.Sensors
{
    abstract class FloatSensorController: SensorControllerBase
    {

        protected SensorEvent CreateSensorEvent(string eventDescription)
        {
            if (!float.TryParse(eventDescription, out var val))
                throw new ArgumentException($"Cannot convert artument '{eventDescription}' to float.");

            return new SensorEvent
            {
                Sensor = SensorModel,
                EventDateTime = DateTime.Now,
                EventFloatValue = val
            };
        }

        public FloatSensorController(Sensor sensorModel) : base(sensorModel)
        {
        }
    }
}
