using System;
using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;
using IoTWorkerService.ModelControllers;

namespace DbCommunicationLib.Controller.Sensors
{
    abstract class SensorControllerBase : ModelControllerBase
    {
        public static SensorControllerBase CreateSensorController(Sensor sensorModel, HomeAutomationContext dbContext)
        {
            var sensorName = sensorModel.Name;
            return sensorName switch
            {
                "PostBox" => new OnOffSensorController(sensorModel, dbContext),
                "PcRoomPress" => new PressureSensorController(sensorModel, dbContext),
                "PcRoomTemp" => new TemperatureSensorController(sensorModel, dbContext),
                _ => throw new NotImplementedException($"Controller for sensor {sensorName} is not implemented")
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
