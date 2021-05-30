using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class Sensor
    {
        public Sensor()
        {
            SensorEvents = new HashSet<SensorEvent>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public bool? InverseLogic { get; set; }
        public short? UnitId { get; set; }
        public short SensorGroupId { get; set; }

        public virtual SensorGroup SensorGroup { get; set; }
        public virtual MeasurementUnit Unit { get; set; }
        public virtual ICollection<SensorEvent> SensorEvents { get; set; }
    }
}
