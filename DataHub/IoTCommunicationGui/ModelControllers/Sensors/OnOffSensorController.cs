using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.Sensors
{
    class OnOffSensorController: SensorControllerBase
    {
        public bool InverseLogic => SensorModel.InverseLogic ?? false;

        public OnOffSensorController(Sensor sensorModel, HomeAutomationContext dbContext) : base(sensorModel, dbContext)
        {
        }
        public override SensorEventControllerBase CreateEventController(string eventDescription)
        {
            if (!bool.TryParse(eventDescription, out var val))
                throw new ArgumentException($"Cannot convert artument '{eventDescription}' to boolean.");

            if (InverseLogic)
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
