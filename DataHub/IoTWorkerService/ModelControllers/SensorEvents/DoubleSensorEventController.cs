using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.SensorEvents
{
    class DoubleSensorEventController: SensorEventControllerBase
    {
        protected DoubleSensorEventController(SensorEvent sensorEventModel, HomeAutomationContext dbContext) : base(sensorEventModel, dbContext)
        {
        }
    }
}
