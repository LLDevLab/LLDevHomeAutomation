using DbCommunicationLib.Dto;
using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.SensorEvents
{
    abstract class SensorEventControllerBase : ISensorEventController
    {
        public SensorEvent SensorEventModel { get; private init; }

        protected SensorEventControllerBase(SensorEvent sensorEventModel)
        {
            SensorEventModel = sensorEventModel;
        }

        public long Id => SensorEventModel.Id;

        public Sensor Sensor => SensorEventModel.Sensor;

        public DateTime EventDateTime => SensorEventModel.EventDateTime;

        public SensorEventTypes EventType => (SensorEventTypes)SensorEventModel.EventType;

        public SensorEventsDto GetDtoObject() => new()
        {
            EventId = SensorEventModel.Id,
            EventType = (SensorEventTypes)SensorEventModel.EventType,
            SensorId = SensorEventModel.SensorId,
            EventDateTime = SensorEventModel.EventDateTime
        };
    }
}
