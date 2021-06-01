using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class SensorGroup
    {
        public SensorGroup()
        {
            ChartSensorGroupsMappings = new HashSet<ChartSensorGroupsMapping>();
            Sensors = new HashSet<Sensor>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short? UnitId { get; set; }

        public virtual MeasurementUnit Unit { get; set; }
        public virtual ICollection<ChartSensorGroupsMapping> ChartSensorGroupsMappings { get; set; }
        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
