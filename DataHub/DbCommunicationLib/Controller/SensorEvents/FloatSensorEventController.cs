using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.SensorEvents
{
    abstract class FloatSensorEventController: SensorEventControllerBase
    {
        public float EventValue
        {
            get
            {
                var val = SensorEventModel.EventFloatValue;
                if (!val.HasValue)
                    throw new ArgumentNullException();

                return val.Value;
            }
        }
        public FloatSensorEventController(SensorEvent sensorEventModel) : base(sensorEventModel)
        {
        }
    }
}
