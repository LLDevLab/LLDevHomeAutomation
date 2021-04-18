using DbCommunicationLib.Dto;
using DbCommunicationLib.Model;
using System;

namespace DbCommunicationLib.Controller.SensorEvents
{
    public interface ISensorEventController
    {
        SensorEvent SensorEventModel { get; }
        long Id { get; }

        Sensor Sensor { get; }

        DateTime EventDateTime { get; }

        SensorEventsDto GetDtoObject();
    }
}
