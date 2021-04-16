using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            SensorEvents = new HashSet<SensorEvent>();
        }

        public short Id { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<SensorEvent> SensorEvents { get; set; }
    }
}
