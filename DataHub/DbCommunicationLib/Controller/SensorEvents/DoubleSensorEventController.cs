using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.SensorEvents
{
    abstract class DoubleSensorEventController: SensorEventControllerBase
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
        public DoubleSensorEventController(SensorEvent sensorEventModel) : base(sensorEventModel)
        {
        }
    }
}
