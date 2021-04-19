using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.SensorEvents
{
    class PressureSensorEventController: DoubleSensorEventController
    {
        public PressureSensorEventController(SensorEvent sensorEventModel) : base(sensorEventModel)
        {
        }
    }
}
