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
                var result = SensorEventModel.Sensor.InverseLogic != true ? SensorEventModel.EventBooleanValue : !SensorEventModel.EventBooleanValue;

                if (result == null)
                    throw new ArgumentNullException();

                return result.Value == true ? OnOffEventValue.On : OnOffEventValue.Off;
            }
        }

        protected override string SensorValue => EventValue.ToString();

        public OnOffSensorEventController(SensorEvent sensorEventModel, HomeAutomationContext dbContext) : base(sensorEventModel, dbContext)
        {
        }
    }
}
