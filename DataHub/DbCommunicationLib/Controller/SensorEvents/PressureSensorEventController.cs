using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.SensorEvents
{
    class PressureSensorEventController: FloatSensorEventController
    {
        public PressureSensorEventController(SensorEvent sensorEventModel) : base(sensorEventModel)
        {
        }
    }
}
