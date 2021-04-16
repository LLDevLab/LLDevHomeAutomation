using System;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class SensorEvent
    {
        public long Id { get; set; }
        public int SensorId { get; set; }
        public DateTime EventDateTime { get; set; }
        public short EventType { get; set; }
        public double? EventFloatValue { get; set; }
        public short? UnitId { get; set; }

        public virtual Sensor Sensor { get; set; }
        public virtual MeasurementUnit Unit { get; set; }
    }
}
