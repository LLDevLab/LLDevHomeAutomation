using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.Sensors
{
    class TemperatureSensorController: FloatSensorController
    {
        public TemperatureSensorController(Sensor sensorModel) : base(sensorModel)
        {
        }

        public override ISensorEventController CreateNewEvent(string eventDescription)
        {
            return new TemperatureSensorEventController(CreateSensorEvent(eventDescription));
        }
    }
}
