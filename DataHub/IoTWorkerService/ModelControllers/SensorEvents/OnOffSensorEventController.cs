using DbCommunicationLib.Model;

namespace DbCommunicationLib.Controller.SensorEvents
{
    class OnOffSensorEventController: SensorEventControllerBase
    {
        public OnOffSensorEventController(SensorEvent sensorEventModel, HomeAutomationContext dbContext) : base(sensorEventModel, dbContext)
        {
        }
    }
}
