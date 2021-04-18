using DbCommunicationLib.Controller.Sensors;
using System;

namespace DbCommunicationLib.Model
{
    public partial class Sensor
    {
        public ISensorController GetController()
        {
            var sensorType = (SensorTypeEnum)SensorType;
            SensorControllerBase result = sensorType switch
            {
                SensorTypeEnum.OnOffSensor => new OnOffSensorController(this),
                SensorTypeEnum.Temperature => new TemperatureSensorController(this),
                SensorTypeEnum.Pressure => new PressureSensorController(this),
                _ => throw new NotImplementedException($"Controller for type {sensorType} is not implemented.")
            };

            return result;
        }
    }
}
