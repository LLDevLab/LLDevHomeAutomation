using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            Sensors = new HashSet<Sensor>();
        }

        public short Id { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
