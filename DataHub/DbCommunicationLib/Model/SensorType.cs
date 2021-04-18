using System.Collections.Generic;

#nullable disable

namespace DbCommunicationLib.Model
{
    public partial class SensorType
    {
        public SensorType()
        {
            Sensors = new HashSet<Sensor>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
