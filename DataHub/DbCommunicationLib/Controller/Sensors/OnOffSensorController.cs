using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.Sensors
{
    class OnOffSensorController: SensorControllerBase
    {
        public OnOffSensorController(Sensor sensorModel) : base(sensorModel)
        {
        }

        bool InverseLogic => SensorModel.InverseLogic ?? false;

        public override ISensorEventController CreateNewEvent(string eventDescription)
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

            return new OnOffSensorEventController(sensorEventModel);
        }
    }
}
