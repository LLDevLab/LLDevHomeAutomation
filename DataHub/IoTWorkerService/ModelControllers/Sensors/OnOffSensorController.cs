using System;
using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.Sensors
{
    class OnOffSensorController: SensorControllerBase
    {
        public OnOffSensorController(Sensor sensorModel, HomeAutomationContext dbContext) : base(sensorModel, dbContext)
        {
        }

        public override SensorEventControllerBase CreateEventController(string eventValue)
        {
            if (!bool.TryParse(eventValue, out var val))
                throw new ArgumentException($"Cannot convert artument '{eventValue}' to boolean.");

            if (SensorModel.InverseLogic.Value)
                val = !val;

            var sensorEventModel = new SensorEvent
            {
                Sensor = SensorModel,
                EventDateTime = DateTime.Now,
                EventBooleanValue = val
            };

            return new OnOffSensorEventController(sensorEventModel, DbContext);
        }
    }
}
