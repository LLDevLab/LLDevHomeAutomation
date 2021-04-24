using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.SensorEvents
{
    class DoubleSensorEventController: SensorEventControllerBase
    {
        public double EventValue
        {
            get
            {
                var val = SensorEventModel.EventDoubleValue;
                if (!val.HasValue)
                    throw new ArgumentNullException();

                return val.Value;
            }
        }

        protected override string SensorValue => EventValue.ToString();

        protected DoubleSensorEventController(SensorEvent sensorEventModel, HomeAutomationContext dbContext) : base(sensorEventModel, dbContext)
        {
        }
    }
}
