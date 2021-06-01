using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            SensorGroups = new HashSet<SensorGroup>();
        }

        public short Id { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<SensorGroup> SensorGroups { get; set; }
    }
}
