#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class ChartSensorGroupsMapping
    {
        public short ChartId { get; set; }
        public short SensorGroupId { get; set; }

        public virtual Chart Chart { get; set; }
        public virtual SensorGroup SensorGroup { get; set; }
    }
}
