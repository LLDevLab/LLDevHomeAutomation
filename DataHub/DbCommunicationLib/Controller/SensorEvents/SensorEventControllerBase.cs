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

        public SensorEventsDto GetDtoObject() => new()
        {
            EventId = SensorEventModel.Id,
            SensorId = SensorEventModel.SensorId,
            EventDateTime = SensorEventModel.EventDateTime
        };
    }
}
