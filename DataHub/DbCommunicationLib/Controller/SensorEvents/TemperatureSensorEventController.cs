using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.SensorEvents
{
    class TemperatureSensorEventController: FloatSensorEventController
    {
        public TemperatureSensorEventController(SensorEvent sensorEventModel) : base(sensorEventModel)
        {
        }
    }
}
