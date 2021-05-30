using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.Sensors
{
    class TemperatureSensorController: DoubleSensorController
    {
        public TemperatureSensorController(Sensor sensorModel, HomeAutomationContext dbContext) : base(sensorModel, dbContext)
        {
        }

        public override SensorEventControllerBase CreateEventController(string sensorValue) => new TemperatureSensorEventController(CreateSensorEvent(sensorValue), DbContext);
    }
}
