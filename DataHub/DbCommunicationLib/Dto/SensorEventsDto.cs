using System;

namespace DbCommunicationLib.Dto
{
    public class SensorEventsDto
    {
        public long EventId { get; set; }
        public SensorEventTypes EventType { get; set; }
        public int SensorId { get; set; }
        public DateTime EventDateTime { get; set; }
    }
}
