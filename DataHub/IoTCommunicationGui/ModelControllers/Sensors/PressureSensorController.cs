using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.Sensors
{
    class PressureSensorController: DoubleSensorController
    {
        public PressureSensorController(Sensor sensorModel, HomeAutomationContext dbContext) : base(sensorModel, dbContext)
        {
        }

        public override SensorEventControllerBase CreateEventController(string sensorValue) => new PressureSensorEventController(CreateNewEvent(sensorValue), DbContext);
    }
}
