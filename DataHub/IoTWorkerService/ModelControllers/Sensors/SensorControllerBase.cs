using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;
using IoTWorkerService.ModelControllers;
using System;

namespace DbCommunicationLib.Controller.Sensors
{
    abstract class SensorControllerBase : ModelControllerBase
    {
        public static SensorControllerBase CreateSensorController(Sensor sensorModel, HomeAutomationContext dbContext)
        {
            var sensorType = (SensorTypeEnum)sensorModel.SensorType;
            return sensorType switch
            {
                SensorTypeEnum.OnOffSensor => new OnOffSensorController(sensorModel, dbContext),
                SensorTypeEnum.Pressure => new PressureSensorController(sensorModel, dbContext),
                SensorTypeEnum.Temperature => new TemperatureSensorController(sensorModel, dbContext),
                _ => throw new NotImplementedException($"Controller for sensor type {sensorType} is not implemented")
            };
        }
        protected Sensor SensorModel { get; private init; }
        public SensorControllerBase(Sensor sensorModel, HomeAutomationContext dbContext) : base(dbContext)
        {
            SensorModel = sensorModel;
        }
        public abstract SensorEventControllerBase CreateEventController(string sensorValue);
    }
}
