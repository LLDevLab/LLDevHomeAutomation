using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.Sensors
{
    class PressureSensorController: FloatSensorController
    {
        public PressureSensorController(Sensor sensorModel) : base(sensorModel)
        {
        }

        public override ISensorEventController CreateNewEvent(string eventDescription)
        {
            return new PressureSensorEventController(CreateSensorEvent(eventDescription));
        }
    }
}
