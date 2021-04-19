using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.SensorEvents
{
    class TemperatureSensorEventController: DoubleSensorEventController
    {
        public TemperatureSensorEventController(SensorEvent sensorEventModel) : base(sensorEventModel)
        {
        }
    }
}
