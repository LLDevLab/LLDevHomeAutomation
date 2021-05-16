#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class ChartSensorMap
    {
        public short ChartId { get; set; }
        public int SensorId { get; set; }

        public virtual Chart Chart { get; set; }
        public virtual Sensor Sensor { get; set; }
    }
}
