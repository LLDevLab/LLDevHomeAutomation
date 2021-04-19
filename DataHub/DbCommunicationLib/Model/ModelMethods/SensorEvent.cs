using DbCommunicationLib.Controller.SensorEvents;
using System;

namespace DbCommunicationLib.Model
{
    public partial class SensorEvent
    {
        public ISensorEventController GetController()
        {
            var sensorTypeEnum = (SensorTypeEnum)Sensor.SensorType;

            SensorEventControllerBase result = sensorTypeEnum switch
            {
                SensorTypeEnum.OnOffSensor => new OnOffSensorEventController(this),
                SensorTypeEnum.Temperature => new TemperatureSensorEventController(this),
                SensorTypeEnum.Pressure => new PressureSensorEventController(this),
                _ => throw new NotImplementedException($"Sensor type {sensorTypeEnum} not implemented.")
            };
            return result;
        }
    }
}
