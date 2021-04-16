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
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public bool? InverseOnOffLogic { get; set; }

        public virtual ICollection<SensorEvent> SensorEvents { get; set; }
    }
}
