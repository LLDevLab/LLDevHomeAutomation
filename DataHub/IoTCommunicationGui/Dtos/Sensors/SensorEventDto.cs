using System;

namespace IoTCommunicationGui.Dtos.Sensors
{
    public class SensorEventDto
    {
        public long Id { get; init; }
        public int SensorId { get; init; }
        public DateTime EventDateTime { get; init; }
        public double? EventDoubleValue { get; init; }
        public bool? EventBooleanValue { get; init; }
    }
}
