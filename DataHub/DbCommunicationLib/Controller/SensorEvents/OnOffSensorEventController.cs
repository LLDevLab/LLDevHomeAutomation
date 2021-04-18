using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.SensorEvents
{
    class OnOffSensorEventController: SensorEventControllerBase
    {
        public OnOffEventValue EventValue
        {
            get
            {
                var result = Sensor.InverseLogic != true ? SensorEventModel.EventBooleanValue : !SensorEventModel.EventBooleanValue;

                if (result == null)
                    throw new ArgumentNullException();

                return result.Value == true ? OnOffEventValue.On : OnOffEventValue.Off;
            }
        }

        public OnOffSensorEventController(SensorEvent sensorEventModel) : base(sensorEventModel)
        {
        }
    }
}
