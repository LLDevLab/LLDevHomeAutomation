using DbCommunicationLib.Controller.Sensors;
using System;

namespace DbCommunicationLib.Model
{
    public partial class Sensor
    {
        public ISensorController GetController()
        {
            SensorControllerBase result = (SensorType)Type switch
            {
                SensorType.OnOffSensor => new OnOffSensorController(this),
                _ => throw new NotImplementedException($"Controller for type {Type} is not implemented.")
            };

            return result;
        }
    }
}
