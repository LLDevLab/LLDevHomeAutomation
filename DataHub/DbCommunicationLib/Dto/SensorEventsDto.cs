using System;

namespace DbCommunicationLib.Dto
{
    public class SensorEventsDto
    {
        public long EventId { get; init; }
        public int SensorId { get; init; }
        public DateTime EventDateTime { get; init; }
    }
}
