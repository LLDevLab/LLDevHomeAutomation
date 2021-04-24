using DbCommunicationLib.Controller.SensorEvents;
using DbCommunicationLib.Model;
using DbCommunicationLib.Model.Interfaces;
using IoTCommunicationGui.ModelControllers;
using System;

namespace DbCommunicationLib.Controller.Sensors
{
    abstract class SensorControllerBase : ModelControllerBase, ISensor
    {
        #region Public properties
        public int Id => SensorModel.Id;
        public string Name => SensorModel.Name;
        public string Description => SensorModel.Description;
        public bool? IsActive => SensorModel.IsActive;
        public SensorTypeEnum SensorType => (SensorTypeEnum)SensorModel.SensorType;
        #endregion Public properties

        #region ISensor
        int ISensor.Id => SensorModel.Id;
        string ISensor.Description => SensorModel.Description;
        bool? ISensor.IsActive => SensorModel.IsActive;
        string ISensor.Name => SensorModel.Name;
        bool? ISensor.InverseLogic => SensorModel.InverseLogic;
        short ISensor.SensorType => SensorModel.SensorType;
        short? ISensor.UnitId => SensorModel.UnitId;
        #endregion ISensor

        public static SensorControllerBase CreateSensorController(Sensor sensorModel, HomeAutomationContext dbContext)
        {
            var sensorType = (SensorTypeEnum)sensorModel.SensorType;
            SensorControllerBase result = sensorType switch
            {
                SensorTypeEnum.OnOffSensor => new OnOffSensorController(sensorModel, dbContext),
                SensorTypeEnum.Temperature => new TemperatureSensorController(sensorModel, dbContext),
                SensorTypeEnum.Pressure => new PressureSensorController(sensorModel, dbContext),
                _ => throw new NotImplementedException($"Controller for type {sensorType} is not implemented.")
            };

            return result;
        }

        public SensorControllerBase(Sensor sensorModel, HomeAutomationContext dbContext) : base(dbContext)
        {
            SensorModel = sensorModel;
        }

        public abstract SensorEventControllerBase CreateEventController(string sensorValue);

        protected Sensor SensorModel { get; private init; }
    }
}
