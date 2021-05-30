using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class SensorGroup
    {
        public SensorGroup()
        {
            Sensors = new HashSet<Sensor>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
