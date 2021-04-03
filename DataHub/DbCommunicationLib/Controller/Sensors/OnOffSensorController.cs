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

        bool InverseOnOffLogic => SensorModel.InverseOnOffLogic ?? false;

        public override ISensorEventController CreateNewEvent(string eventDescription)
        {
            SensorEventTypes eventType;

            if (!bool.TryParse(eventDescription, out var val))
                throw new ArgumentException($"Cannot convert artument '{eventDescription}' to boolean.");

            if (InverseOnOffLogic)
                eventType = val == false ? SensorEventTypes.On : SensorEventTypes.Off;
            else
                eventType = val == true ? SensorEventTypes.On : SensorEventTypes.Off;

            var sensorEventModel = new SensorEvent
            {
                Sensor = SensorModel,
                EventDateTime = DateTime.Now,
                EventType = (short)eventType
            };

            return new OnOffSensorEventController(sensorEventModel);
        }
    }
}
