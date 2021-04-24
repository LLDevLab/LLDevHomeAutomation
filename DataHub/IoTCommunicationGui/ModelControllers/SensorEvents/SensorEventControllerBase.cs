using DbCommunicationLib.Model;
using DbCommunicationLib.Model.Interfaces;
using IoTCommunicationGui.ModelControllers;
using System;

namespace DbCommunicationLib.Controller.SensorEvents
{
    abstract class SensorEventControllerBase : ModelControllerBase, ISensorEvent
    {
        public long Id => SensorEventModel.Id;
        public DateTime EventDateTime => SensorEventModel.EventDateTime;
        protected abstract string SensorValue { get; } 
        protected SensorEvent SensorEventModel { get; private init; }

        #region ISensorEvent
        long ISensorEvent.Id => SensorEventModel.Id;
        int ISensorEvent.SensorId => SensorEventModel.SensorId;
        DateTime ISensorEvent.EventDateTime => SensorEventModel.EventDateTime;
        double? ISensorEvent.EventDoubleValue => SensorEventModel.EventDoubleValue;
        bool? ISensorEvent.EventBooleanValue => SensorEventModel.EventBooleanValue;
        #endregion ISensorEvent

        protected SensorEventControllerBase(SensorEvent sensorEventModel, HomeAutomationContext dbContext) : base(dbContext)
        {
            SensorEventModel = sensorEventModel;
        }
    }
}
