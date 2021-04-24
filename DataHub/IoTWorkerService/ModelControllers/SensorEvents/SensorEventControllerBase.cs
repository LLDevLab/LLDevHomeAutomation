using DbCommunicationLib.Model;
using IoTWorkerService.ModelControllers;

namespace DbCommunicationLib.Controller.SensorEvents
{
    abstract class SensorEventControllerBase : ModelControllerBase
    {
        protected SensorEvent SensorEventModel { get; private init; }

        protected SensorEventControllerBase(SensorEvent sensorEventModel, HomeAutomationContext dbContext) : base(dbContext)
        {
            SensorEventModel = sensorEventModel;
        }

        public int Save()
        {
            DbContext.SensorEvents.Add(SensorEventModel);
            return DbContext.SaveChanges();
        }
    }
}
